using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.IDM
{
    public class ApplicationUser
    {
        public int IDMUserID { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Division { get; set; }
        public string Section { get; set; }
        public string Office { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string EmployeeTitle { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        #region Constructors

        public ApplicationUser()
        {

        }

        public ApplicationUser(int IDMUserID, string UserName, string Roles, string FirstName, string LastName, string Division, string Section, string Office, string Phone, string Email, string EmployeeNumber = null)
        {
            this.IDMUserID = IDMUserID;
            this.UserName = UserName;
            this.Roles = (from s in Roles.Split(',')
                          select s.Trim()).ToList();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FullName = FirstName + " " + LastName;
            this.Division = Division;
            this.Section = Section;
            this.Office = Office;
            this.Phone = Phone;
            this.Email = Email;
            this.EmployeeNumber = EmployeeNumber;
        }

        #endregion //Constructors

        #region Get and Caching

        public static List<ApplicationUser> GetApplicationUsers()
        {
            List<ApplicationUser> users = null;

            if (HttpContext.Current != null && HttpContext.Current.Cache["ApplicationUsers"] != null)
            {
                users = (List<ApplicationUser>)HttpContext.Current.Cache["ApplicationUsers"];
            }
            if (users == null)
            {
                users = ApplicationUser.GetDummyUsers();
                //users = IDMApplicationUser.GetAllIDMUser().OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToList();
                HttpContext.Current.Cache["ApplicationUsers"] = users;
            }

            return users;
        }

        public static ApplicationUser GetUser(string username)
        {
            return GetApplicationUsers().Where(m => m.UserName == username).FirstOrDefault();
        }

        #endregion //Get and Cache

        #region Test Helper Method

        public static List<ApplicationUser> GetDummyUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            users.Add(new ApplicationUser(1, "EBenson", "Supervisor", "Ed", "Benson", "Code", "10.7", "Valley", "(855) 682-7604", "Ed.Benson@lacity.org"));
            users.Add(new ApplicationUser(2, "JMcdaniel", "Supervisor,Employee", "Jeremy", "Mcdaniel", "Code", "4.3", "South", "(822) 779-9355", "Jeremy.Mcdaniel@lacity.org"));
            users.Add(new ApplicationUser(3, "JRodriguez", "Employee", "Joshua", "Rodriguez", "Compliance", "5.5", "South", "(844) 249-4805", "Joshua.Rodriguez@lacity.org"));
            users.Add(new ApplicationUser(4, "MDelgado", "Supervisor,Employee", "Marianne", "Delgado", "Compliance", "4.3", "North", "(822) 338-4346", "Marianne.Delgado@lacity.org"));
            users.Add(new ApplicationUser(5, "TPerez", "Employee", "Thomas", "Perez", "Rent", "5.1", "East", "(899) 387-9918", "Thomas.Perez@lacity.org"));
            users.Add(new ApplicationUser(6, "SParks", "Supervisor", "Stewart", "Parks", "Rent", "3.9", "West", "(822) 876-2317", "Stewart.Parks@lacity.org"));
            users.Add(new ApplicationUser(7, "CWells", "Director", "Caroline", "Wells", "Reap", "3.9", "West", "(833) 669-4752", "Caroline.Wells@lacity.org"));
            users.Add(new ApplicationUser(8, "MMontgomery", "Director,Employee", "Melody", "Montgomery", "Reap", "4.3", "North", "(899) 805-2522", "Melody.Montgomery@lacity.org"));
            users.Add(new ApplicationUser(9, "WSimmons", "Director,Supervisor", "Willis", "Simmons", "Fire", "8.7", "Valley", "(822) 198-0167", "Willis.Simmons@lacity.org"));
            users.Add(new ApplicationUser(10, "BWagner", "Admin", "Barry", "Wagner", "Fire", "4.7", "Valley", "(899) 332-7502", "Barry.Wagner@lacity.org"));
            users.Add(new ApplicationUser(11, "HMaldonado", "Supervisor", "Homer", "Maldonado", "Zoning", "7.5", "South", "(899) 726-4886", "Homer.Maldonado@lacity.org"));
            users.Add(new ApplicationUser(12, "MPhelps", "Supervisor,Employee", "Marcia", "Phelps", "Zoning", "8.3", "North", "(822) 919-4412", "Marcia.Phelps@lacity.org"));
            users.Add(new ApplicationUser(13, "WFisher", "Employee", "Wilbert", "Fisher", "GM Office", "11.1", "East", "(833) 116-2732", "Wilbert.Fisher@lacity.org"));
            users.Add(new ApplicationUser(14, "DBarnes", "Supervisor,Employee", "Dora", "Barnes", "Planning", "5.1", "East", "(899) 758-2613", "Dora.Barnes@lacity.org"));
            users.Add(new ApplicationUser(15, "KKelley", "Employee", "Kim", "Kelley", "Planning", "4.7", "Valley", "(844) 398-1848", "Kim.Kelley@lacity.org"));
            users.Add(new ApplicationUser(16, "VKnight", "Supervisor", "Vernon", "Knight", "Permit", "4.3", "North", "(822) 672-0946", "Vernon.Knight@lacity.org"));
            users.Add(new ApplicationUser(17, "KWeaver", "Director", "Ken", "Weaver", "Permit", "3.9", "East", "(899) 522-3654", "Ken.Weaver@lacity.org"));
            users.Add(new ApplicationUser(18, "JNichols", "Director,Employee", "Jean", "Nichols", "Inspection", "3.9", "West", "(855) 025-6390", "Jean.Nichols@lacity.org"));
            users.Add(new ApplicationUser(19, "RSutton", "Director,Supervisor", "Ramona", "Sutton", "Inspection", "5.1", "North", "(822) 889-7374", "Ramona.Sutton@lacity.org"));
            users.Add(new ApplicationUser(20, "BBurton", "Admin", "Brandy", "Burton", "Emergency", "4.7", "West", "(811) 560-4164", "Brandy.Burton@lacity.org"));
            users.Add(new ApplicationUser(21, "TIngram", "Employee", "Tami", "Ingram", "Emergency", "3.5", "South", "(822) 870-4257", "Tami.Ingram@lacity.org"));
            users.Add(new ApplicationUser(22, "SWelch", "Supervisor,Employee", "Sheryl", "Welch", "Prevention", "7.9", "West", "(844) 730-1218", "Sheryl.Welch@lacity.org"));
            users.Add(new ApplicationUser(23, "AVasquez", "Employee", "Anita", "Vasquez", "Prevention", "4.7", "Valley", "(855) 988-2632", "Anita.Vasquez@lacity.org"));
            users.Add(new ApplicationUser(24, "LPena", "Supervisor", "Lance", "Pena", "Prevention", "5.1", "East", "(855) 026-1819", "Lance.Pena@lacity.org"));
            users.Add(new ApplicationUser(25, "AQuinn", "Director", "Abraham", "Quinn", "Code", "11.7", "South", "(822) 802-1505", "Abraham.Quinn@lacity.org"));


            return users;
        }

        #endregion //Test Helper Method
    }
}
