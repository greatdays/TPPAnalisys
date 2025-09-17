using DeveloperPortal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IContactIdentifiersService
    {
        /// <summary>
        /// Save Contact
        /// </summary>
        /// <param name="contactIdentifierMdl"></param>
        /// <returns></returns>
        Task<int> SaveContact(ContactIdentifierModel contactRenderModel);
    }
}
