using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.IDM
{
    internal class Constants
    {

    }
    public class AppConstant
    {
        public const string AppSource = "ACHP";
        public const string WebRegister = "Web Register";
        public const string AppSourceWebLink = "Web Link";
    }
    public enum ContactMethods
    {
        None = 1,
        USMail = 2,
        Phone = 3
    }
}
