using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Domain.ProjectDetail;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IProjectDetailRepository
    {
        bool UpdateUnitDetails(UnitDataModel unitModel, string userName);
    }
}
