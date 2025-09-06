using System.Web;

namespace HCIDLA.ServiceClient.VirusScan
{
    public class VirusScan
    {
        #region Scan for virus
        /// <summary>
        /// Scan file for Virus using VScan service
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool ScanForVirus(HttpPostedFileBase file)
        {
            //create the virus scan client
            var vscanClient = new VScan.IvscanClient();

            byte[] fileByte = new byte[file.ContentLength];
            file.InputStream.Read(fileByte, 0, fileByte.Length);

            //scan your bytes data
            var result = vscanClient.scan(fileByte); //the result object will 

            if (result != null)
            {
                if (result.Infected) // file is infected w/ a virus
                {
                    vscanClient.Close();
                    return false;
                }
                else
                {
                    vscanClient.Close();
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
