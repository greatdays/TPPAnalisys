namespace DeveloperPortal.Constants
{
    public class Application
    {
        static IConfiguration _config;

        public static string Name = _config["ThisApplication:Application"];
    }

    public class AppConstant
    {
        public const string AppSource = "ACHP";
        public const string WebRegister = "Web Register";
        public const string AppSourceWebLink = "Web Link";
    }
}
