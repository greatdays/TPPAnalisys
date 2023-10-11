using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.IDM
{
    public class SignupModel
    {
    }

    public class OrganizationContactModel
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string EmailDomain { get; set; }

        public string HouseNum { get; set; }
        public string HouseFracNum { get; set; }
        public string PreDirection { get; set; }
        public string StreetName { get; set; }
        public string StreetTypeCd { get; set; }
        public string PostDirection { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ContactAttribute { get; set; }
        public string ContactAddressAttribute { get; set; }
        public string IDMUserName { get; set; }

    }
}
