using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.IDM;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class FundingSourceRepository : IFundingSourceRepository
    {
        private readonly AAHREntities _context;

        public FundingSourceRepository(AAHREntities context)
        {
            _context = context;
        }

        

        

    }
}
