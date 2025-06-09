using DeveloperPortal.DataAccess.Entity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.PropertySnapshot
{
    public class ContactIdentifiersService
    {
        /// <summary>
        /// Get Contact based on Contact Id
        /// </summary>
        /// <param name="contactIdentifierMdl"></param>
        /// <returns></returns>
        public int GetContactByContactId(int contactId)
        {
            using (AAHREntities _dbContext = new())
            {
                return _dbContext.ContactIdentifiers.Where(x => x.ContactId == contactId && x.IsDeleted == false).FirstOrDefault()?.ContactIdentifierId ?? 0;
            }
        }
    }
}
