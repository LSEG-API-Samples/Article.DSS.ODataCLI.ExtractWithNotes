//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:6.0.30
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 11/18/2024 4:56:07 PM
namespace DSSAuthentication
{
    /// <summary>
    /// There are no comments for Authentication in the schema.
    /// </summary>
    public partial class Authentication : global::Microsoft.OData.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new Authentication object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public Authentication(global::System.Uri serviceRoot) :
                this(serviceRoot, global::Microsoft.OData.Client.ODataProtocolVersion.V4)
        {
        }

        /// <summary>
        /// Initialize a new Authentication object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public Authentication(global::System.Uri serviceRoot, global::Microsoft.OData.Client.ODataProtocolVersion protocolVersion) :
                base(serviceRoot, protocolVersion)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
            this.Format.UseJson();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            global::System.Type resolvedType = this.DefaultResolveType(typeName, "DataScope.Select.Api.Authentication", "DSSAuthentication");
            if ((resolvedType != null))
            {
                return resolvedType;
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("DSSAuthentication", global::System.StringComparison.Ordinal))
            {
                return string.Concat("DataScope.Select.Api.Authentication.", clientType.Name);
            }
            return null;
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
            private static global::Microsoft.OData.Edm.IEdmModel ParsedModel = LoadModelFromString();

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
            private const string filePath = @"DSSAuthenticationCsdl.xml";

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
            public static global::Microsoft.OData.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
            private static global::Microsoft.OData.Edm.IEdmModel LoadModelFromString()
            {
                global::System.Xml.XmlReader reader = CreateXmlReader();
                try
                {
                    global::System.Collections.Generic.IEnumerable<global::Microsoft.OData.Edm.Validation.EdmError> errors;
                    global::Microsoft.OData.Edm.IEdmModel edmModel;

                    if (!global::Microsoft.OData.Edm.Csdl.CsdlReader.TryParse(reader, false, out edmModel, out errors))
                    {
                        global::System.Text.StringBuilder errorMessages = new global::System.Text.StringBuilder();
                        foreach (var error in errors)
                        {
                            errorMessages.Append(error.ErrorMessage);
                            errorMessages.Append("; ");
                        }
                        throw new global::System.InvalidOperationException(errorMessages.ToString());
                    }

                    return edmModel;
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
            private static global::System.Xml.XmlReader CreateXmlReader()
            {
                try
                {
                    var assembly = global::System.Reflection.Assembly.GetExecutingAssembly();
                    var resourcePath = global::System.Linq.Enumerable.Single(assembly.GetManifestResourceNames(), str => str.EndsWith(filePath));
                    global::System.IO.Stream stream = assembly.GetManifestResourceStream(resourcePath);
                    return global::System.Xml.XmlReader.Create(new global::System.IO.StreamReader(stream));
                }
                catch(global::System.Xml.XmlException e)
                {
                    throw new global::System.Xml.XmlException("Failed to create an XmlReader from the stream. Check if the resource exists.", e);
                }
            }
        }
        /// <summary>
        /// This method is deprecated.  Please do not use.  It will be removed at some point in the future. When using the toolkit, use the token to create a context.  There are parameters on the context to handle an invalid token. When you are using the REST API without the toolkit, pass the token on the request header.  If it is invalid, you will receive an authorization error.  At this point you can call the RequestToken method to retrieve a new token and try the request again.
        /// </summary>
        public virtual global::Microsoft.OData.Client.DataServiceQuerySingle<global::DSSAuthentication.ValidateTokenResult> ValidateToken(string Token)
        {
            return this.CreateFunctionQuerySingle<global::DSSAuthentication.ValidateTokenResult>("", "ValidateToken", false, new global::Microsoft.OData.Client.UriOperationParameter("Token", Token));
        }
        /// <summary>
        /// Returns an authentication token that must be applied to all requests.
        /// </summary>
        public virtual global::Microsoft.OData.Client.DataServiceActionQuerySingle<string> RequestToken(global::DSSAuthentication.Credentials Credentials)
        {
            return new global::Microsoft.OData.Client.DataServiceActionQuerySingle<string>(this, this.BaseUri.OriginalString.Trim('/') + "/RequestToken", new global::Microsoft.OData.Client.BodyOperationParameter("Credentials", Credentials));
        }
    }
    /// <summary>
    /// Credentials for authentication.
    /// </summary>
    public partial class Credentials
    {
        /// <summary>
        /// There are no comments for Property Username in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public virtual string Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                this.OnUsernameChanging(value);
                this._Username = value;
                this.OnUsernameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Username;
        partial void OnUsernameChanging(string value);
        partial void OnUsernameChanged();
        /// <summary>
        /// There are no comments for Property Password in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public virtual string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this.OnPasswordChanging(value);
                this._Password = value;
                this.OnPasswordChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Password;
        partial void OnPasswordChanging(string value);
        partial void OnPasswordChanged();
    }
    /// <summary>
    /// There are no comments for ValidateTokenResult in the schema.
    /// </summary>
    public partial class ValidateTokenResult
    {
        /// <summary>
        /// Create a new ValidateTokenResult object.
        /// </summary>
        /// <param name="isValid">Initial value of IsValid.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static ValidateTokenResult CreateValidateTokenResult(bool isValid)
        {
            ValidateTokenResult validateTokenResult = new ValidateTokenResult();
            validateTokenResult.IsValid = isValid;
            return validateTokenResult;
        }
        /// <summary>
        /// There are no comments for Property IsValid in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "IsValid is required.")]
        public virtual bool IsValid
        {
            get
            {
                return this._IsValid;
            }
            set
            {
                this.OnIsValidChanging(value);
                this._IsValid = value;
                this.OnIsValidChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private bool _IsValid;
        partial void OnIsValidChanging(bool value);
        partial void OnIsValidChanged();
        /// <summary>
        /// There are no comments for Property Expires in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public virtual global::System.Nullable<global::System.DateTimeOffset> Expires
        {
            get
            {
                return this._Expires;
            }
            set
            {
                this.OnExpiresChanging(value);
                this._Expires = value;
                this.OnExpiresChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.Nullable<global::System.DateTimeOffset> _Expires;
        partial void OnExpiresChanging(global::System.Nullable<global::System.DateTimeOffset> value);
        partial void OnExpiresChanged();
    }
}
