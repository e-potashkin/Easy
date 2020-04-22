namespace Easy.WebApi.Configuration
{
    /// <summary>
    /// API versions names <br/>
    /// Major, optional minor version, and status <br/>
    /// VVV at
    /// https://github.com/Microsoft/aspnet-api-versioning/wiki/Version-Format
    /// </summary>
    public static class Api
    {
        public const string V1 = "1.0";

        public const string V2 = "2.0";
        
        public const string Template = "api/v{version:apiVersion}/[controller]";

        public static class Routes
        {
            public static class Authentication
            {
                public const string Register = "register";

                public const string Login = "login";

                public const string Verify = "verify";
            }
        }
    }
}