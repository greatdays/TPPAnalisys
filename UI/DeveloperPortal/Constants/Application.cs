namespace DeveloperPortal.Constants
{
    public class Application
    {
        private string? retVal;
        IConfiguration _config;
        public Application(IConfiguration config)
        {
            _config = config;
        }

        public string GetConfigValue(string key)
        {
            retVal = string.Empty;
            switch (key)
            {
                case "Name":
                    retVal = _config["AppSettings:Application"] ?? string.Empty;
                    break;
                default:
                    break;
            }
            return retVal;
        }
    }

    public class AppConstant
    {
        public const string AppSource = "ACHP";
        public const string WebRegister = "Web Register";
        public const string AppSourceWebLink = "Web Link";
        public const string TPPSource = "AAHRDeveloperPortal";
    }
}
