using DeveloperPortal.Domain.IDM;
using Microsoft.AspNetCore.Http;
using DeveloperPortal.Models.IDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Interfaces
{
    public interface ISignInServices
    {
        /// <summary>
        /// Validates credentials via the SQL (IDM) path.
        /// Returns the IDM AuthenticateResponse, including UserId, Username, and Roles.
        /// </summary>
        Task<AuthenticateResponse> AuthenticateSqlAsync(LoginModel model);

        /// <summary>
        /// Validates an already‐authenticated Angeleno user by looking them up in IDM
        /// (or auto‐provisioning them) so you get back an AuthenticateResponse.
        /// </summary>
        Task<AuthenticateResponse> AuthenticateAngelenoAsync(string email, string firstName, string lastName);

        /// <summary>
        /// Issues the TPP session cookie, ClaimsPrincipal, and UserSession based on
        /// a successful AuthenticateResponse.
        /// </summary>
        Task SignInAsync(AuthenticateResponse authResponse, HttpContext httpContext, bool rememberMa);
    }
}
