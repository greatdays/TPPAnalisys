using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DeveloperPortal.Pages
{
    public class DashboardModel : PageModel
    {
        public IConfigurationRoot Configuration { get; set; }
        public int RecordCount { get; set; }

        public List<string?> NewProjectsList { get; set; } = new List<string?>();
        //public Startup(IConfigurationRoot configuration) { }
        public void OnGet()
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = configBuilder.Build();
            
            string? connString = Configuration.GetConnectionString("AAHR");            
            SqlConnection conn  = new SqlConnection(connString);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "[AAHPCC].[uspRoGetAllConstructionCases]";
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = comm.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            conn.Close();

            

            //Console.WriteLine(dt.Rows.Count);
            RecordCount = dt.Rows.Count;
            DataRow[] drNewProjColl = dt.Select("Status='Under Document Review'"); //Type='New Construction Project' AND
            List<string?> lstNewProjects = new List<string?>();
            //lstNewProjects = drNewProjColl.ToList();

            NewProjectsList = drNewProjColl.Select(x => x["ProjectName"].ToString()).ToList();
            NewProjectsList.Sort();
            RecordCount = NewProjectsList.Count;
        }
    }
}
