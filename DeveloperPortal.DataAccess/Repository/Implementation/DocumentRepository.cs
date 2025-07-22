using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AAHREntities _context;

        public DocumentRepository(AAHREntities context)
        {
            _context = context;
        }


        

        
    }
}
