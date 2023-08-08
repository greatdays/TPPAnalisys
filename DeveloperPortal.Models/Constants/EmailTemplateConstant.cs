namespace DeveloperPortal.Constants
{
    public static class EmailTemplateConstant
    {
        public const string ProgramFooterTemplate = "AcHP Email Footer";
        public const string SystemFooterTemplate = "AAHR Email Footer";
        public static Dictionary<string, string> EmailConstants = new Dictionary<string, string>
        {
            { "System Name", "Developer Portal" },
            { "System Acronym", "3PP" },
            { "Program Domain", "<a href='http://www.accesshousingla.org'>AccessHousingLA.org</a>" },
            { "Program Address", "<address style='font-style:normal;'>221 N.Figueroa St #1400, Los Angeles, CA 90012</address>" },
            { "Program Email", "<a href='mailto:lahd.achp@lacity.org'>lahd.achp@lacity.org</a>" },
            { "Program Phone", "<a href='tel:213-808-8550'>(213) 808-8550</a>" },
            { "Department Name", "Los Angeles Housing Department" },
            { "Department Acronym", "LAHD" },
            { "Department Domain", "<a href='https://housing.lacity.org/'>housing.lacity.org</a>" },
            { "Program Name", "Accessible Housing Program" },
            { "Program Acronym", "AcHP" }
        };
    }
}
