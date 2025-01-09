using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.Models.IDM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.ViewModel
{
    public class LinksViewModel
    {
        private IHttpContextAccessor _httpContextAccessor;
        #region Members

        public string Title { get; set; }
        public string DisplayStyle { get; set; } // Vertical, Horizontal
        public bool IsDisplayFavourite { get; set; }
        public bool IsDisplayIcon { get; set; }
        public List<LinkItem> LinkItems { get; set; }

        public class LinkItem
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Parameter { get; set; }
            public string ImageURL { get; set; }
            public int ImageHeight { get; set; }
            public int ImageWidth { get; set; }
            public string OpenTarget { get; set; }

        }

        #endregion // Members

        /// <summary>
        /// Default constructor
        /// </summary>
        public LinksViewModel()
        {
            /* Initialize Link Items list */
            this.LinkItems = new List<LinkItem>();
        }

        /// <summary>
        /// Copy Display configuration data into View Model.
        /// </summary>
        /// <param name="linksDisplayConfiguration">Display Configuration entity</param>
        internal void FetchDisplayConfiguration(Links_DisplayConfig linksDisplayConfiguration)
        {
            /* Copy Display Config */
            this.Title = linksDisplayConfiguration.Name;
            this.DisplayStyle = linksDisplayConfiguration.DisplayOption;
            this.IsDisplayIcon = (bool)linksDisplayConfiguration.IsDisplayIcon;
            this.IsDisplayFavourite = (bool)linksDisplayConfiguration.IsDisplayFavouriteLinks;

            /* Get no. of links to display */
            int noOfLinkToDisplay = (int)(linksDisplayConfiguration.NoOfLinkToDisplay == null ? 0 : linksDisplayConfiguration.NoOfLinkToDisplay);

            /* Get the list of links based on following.
                 * - IsActive
                 * - ViewOrder
                 * - NoOfLinksToDisplay
                 * */
            List<Links_LinkDetails> linkDetails = linksDisplayConfiguration.Links_LinkDetails
                                                      .Where(l => l.IsActive == true)
                                                      .OrderBy(l => l.ViewOrder)
                                                      .Take(noOfLinkToDisplay)
                                                      .ToList();
            if (0 != linkDetails.Count)
            {
                foreach (var linkDetail in linkDetails)
                {
                    LinkItem linkItem = new LinkItem();

                    /* Fetch attributes */
                    linkItem.Name = linkDetail.Name;
                    linkItem.Address = linkDetail.Address;
                    linkItem.Parameter = linkDetail.Parameter;
                    linkItem.OpenTarget = false == linkDetail.IsOpenNewWindow ? "_self" : "_blank";

                    /* Fetch Icon details */
                    if (true == linksDisplayConfiguration.IsDisplayIcon)
                    {
                        Links_Images linkImages = null;

                        /* Check if same icon or specific icons are required. */
                        if (true == linksDisplayConfiguration.IsDisplayIcon)
                        {
                            /* Copy from Display configureation */
                            linkImages = linksDisplayConfiguration.Links_Images;
                        }
                        else
                        {
                            /* Copy from individual Link detail */
                            linkImages = linkDetail.Links_Images;
                        }
                        /* Copy Icon detail */
                        if (null != linkDetail.Links_Images)
                        {
                            linkItem.ImageURL = linkImages.ImageName; //TODO: Need to rename as URL instead of name
                            linkItem.ImageHeight = (int)linkImages.Height;
                            linkItem.ImageWidth = (int)linkImages.Width;
                        }
                        /* Set to default icon */
                        {
                            linkItem.ImageURL = "Default Icon Link"; //TODO: Need to provide default link
                            linkItem.ImageHeight = 16;
                            linkItem.ImageWidth = 16;
                        }
                    }

                    /* Add List to Item */
                    this.LinkItems.Add(linkItem);
                } /* foreach (var linkDetail in linkDetailsList) */
            } /* if (0 != linkDetailsList.Count) */

            return;
        }

        /// <summary>
        /// Fetch Parameters for link items
        /// </summary>
        public void FetchParameterValues(IDictionary<string, object> routeData, NameValueCollection appSettings)
        {
            foreach (var item in LinkItems)
            {
                if (null != item.Parameter)
                {
                    //Fetch value of parameter
                    if (item.Parameter.StartsWith("$") && item.Parameter.EndsWith("$")) // For QueryString
                    {
                        string param = item.Parameter.Trim().Remove(item.Parameter.Trim().LastIndexOf('$')).Remove(0, 1);
                        HttpRequest? request = _httpContextAccessor.HttpContext?.Request;
                        string queryStringValue = string.Empty;
                        if (request != null)
                        {
                            queryStringValue = request.Query["param"].ToString(); 
                        }
                        //string paramValue = routeData[param] != null ? (!string.IsNullOrEmpty(Convert.ToString(routeData[param])) ? Convert.ToString(routeData[param]) : Convert.ToString(System.Web.HttpContext.Current.Request.QueryString[param])) : Convert.ToString(System.Web.HttpContext.Current.Request.QueryString[param]);
                        string paramValue = routeData[param] != null ? (!string.IsNullOrEmpty(Convert.ToString(routeData[param])) ? Convert.ToString(routeData[param]) : queryStringValue) : queryStringValue;
                        item.Parameter = param + "=" + paramValue;

                    }
                    if (item.Parameter.StartsWith("^") && item.Parameter.EndsWith("^")) // For Session
                    {
                        UserSession userSession = new UserSession(_httpContextAccessor);
                        string param = item.Parameter.Trim().Remove(item.Parameter.Trim().LastIndexOf('^')).Remove(0, 1);
                        string paramValue = routeData[param] != null ? (!string.IsNullOrEmpty(Convert.ToString(routeData[param])) ? Convert.ToString(routeData[param]) : Convert.ToString(userSession.GetValueFromSession(param))) : Convert.ToString(userSession.GetValueFromSession(param));
                        item.Parameter = param + "=" + paramValue;

                    }
                }
            }
        }


    }
}
