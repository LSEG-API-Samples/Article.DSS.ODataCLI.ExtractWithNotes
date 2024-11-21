using DSSAuthentication;
using Microsoft.OData.Client;
using DSSExtractions.DataScope.Select.Api.Content;
using DSSExtractions.DataScope.Select.Api.Extractions.ExtractionRequests;
using DSSExtractions.DataScope.Select.Api.Extractions.ReportTemplates;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Runtime.InteropServices.JavaScript;


namespace ODataDSSExtractWithNotes
{
    internal class Program
    {
        private string DSSUsername = "<DSS Username>";
        private string DSSPassword = "<DSS Password>;
        static void Main(string[] args)
        {
            Program prog = new Program();
            var token = prog.GetToken();
            var requestMsg = prog.GetExtractionRequest();

            prog.SendRequest(token, requestMsg);
        }
        public string? GetToken()
        {
            Console.WriteLine("\n### Get a token ###");
            try
            {
                Authentication auth = new Authentication(new Uri("https://selectapi.datascope.refinitiv.com/restapi/v1/Authentication"));
                var resp = auth.RequestToken(new Credentials { Username = DSSUsername, Password = DSSPassword });
                var token = resp.GetValue();

                Console.WriteLine($"Token: {token}");
                return token;


            }
            catch (DataServiceQueryException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return null;
            }
        }

        public void SendRequest(string token, string jsonStr)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://selectapi.datascope.refinitiv.com/RestApi/v1/Extractions/ExtractWithNotes");

            requestMessage.Headers.Add("Prefer", "respond-async");
            requestMessage.Headers.Add("Authorization", "Token " + token);


            requestMessage.Content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var response = client.Send(requestMessage);

            while (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Console.WriteLine(response.Headers.GetValues("Location").First());
                var requestLocation = new HttpRequestMessage(HttpMethod.Get, response.Headers.GetValues("Location").First());
                requestLocation.Headers.Add("Prefer", "respond-async");
                requestLocation.Headers.Add("Authorization", "Token " + token);
                Thread.Sleep(2000);
                response = client.Send(requestLocation);
            }

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return;
            }

            var strResponse = response.Content.ReadAsStringAsync().Result;
            
            JsonNode responseJSON = JsonSerializer.Deserialize<JsonNode>(strResponse);

            JsonArray array = responseJSON["Contents"] as JsonArray;

            Console.WriteLine(responseJSON["Notes"]);

            foreach (JsonObject row in array)
            {
                Console.WriteLine("");
                foreach(var value in row.AsEnumerable())
                {
                    Console.WriteLine($"{value.Key}: {value.Value}");
                }         
            }


        }

        public string GetExtractionRequest()
        {
          

            TermsAndConditionsExtractionRequest termRequest = new TermsAndConditionsExtractionRequest();

            InstrumentIdentifierList instruments = InstrumentIdentifierList.CreateInstrumentIdentifierList(true);
            Collection<InstrumentIdentifier> list = new Collection<InstrumentIdentifier>();
            list.Add(new InstrumentIdentifier { Identifier = "LSEG.L", IdentifierType = IdentifierType.Ric });
            list.Add(new InstrumentIdentifier { Identifier = "GOOG.O", IdentifierType = IdentifierType.Ric });
            list.Add(new InstrumentIdentifier { Identifier = "IBM.N", IdentifierType = IdentifierType.Ric });
            instruments.InstrumentIdentifiers = list;            

           
            termRequest.IdentifierList = instruments;
            termRequest.ContentFieldNames = new Collection<string> { "CUSIP", "SEDOL", "Exchange Code", "Currency Code" };
            termRequest.Condition = new TermsAndConditionsCondition();

            var request = new
            {
                ExtractionRequest = termRequest
            };

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            
            var requestStr = JsonSerializer.Serialize(request, options);
            
            Console.WriteLine(requestStr);
            return requestStr;

        }
    }
}
