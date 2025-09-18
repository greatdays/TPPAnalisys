using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface ILutRepository
    {
        /// <summary>
        /// LutPreDirs
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        Task<List<LutPreDir>> LutPreDirs();

        /// <summary>
        /// LutStates
        /// </summary>
        /// <returns></returns>
        Task<List<LutState>> LutStates();
    }
}
