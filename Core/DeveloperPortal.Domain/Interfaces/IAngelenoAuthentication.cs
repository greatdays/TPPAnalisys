using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Interfaces
{
    public interface IAngelenoAuthentication
    {
        public Task<string> GenerateSessionID();
        public Task<string> ValidateCredientials(string tokenId);
    }
}
