using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.EntityModels.IDM;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace DeveloperPortal.DataAccess.Entity.ViewModel
{
    public partial class ActionViewModel
    {
        private IConfiguration _config;
        AppConfiguration appConfig;
        bool IsNotificationEnable;
        public ActionViewModel(IConfiguration config)
        {
            _config = config;
            appConfig = new AppConfiguration(_config);
            IsNotificationEnable = appConfig.GetConfigValue<bool>("SendNotification");
        }
        #region Variable Declaration

        //AppConfiguration appConfig = new AppConfiguration(_config);
        //bool IsNotificationEnable = appConfig.GetConfigValue<bool>("SendNotification");

        #endregion // Variable Declaration

        public string UserName { get; set; }
        public List<string> roles { get; set; }
        public string CaseStatus { get; set; }
        public string ActionName { get; set; }
        public string ActionDisplayName { get; set; }
        public string CaseId { get; set; }
        public string AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public Dictionary<string, string> NotificationData { get; set; } = new Dictionary<string, string>();
        public bool? isNotificationToRoles { get; set; }
        public string CaseTypeAbbr { get; set; }
        // public DocumentType docType { get; set; }
        public bool IsSendNotification { get; set; }
        public bool IsAuto { get; set; }
        public Nullable<int> FormId { get; set; }

        #region Execute Action

        /// <summary>
        /// Execute the workflow action.
        /// Update Case status based on workflow.
        /// Update Case Log.
        /// </summary>
        /// <param name="comment">Optional comment</param>
        /// <param name="workLog">Optional workflow</param>
        /// <param name="username"></param>
        /// <param name="refrenceType">Used for saving comment liek case,caselog....</param>
        /// <param name="refrenceId">Used for saving comment as per refrecnceType</param>
        public void ExecuteAction(string comment = null!, string workLog = null!, string username = null!, string refrenceType = null!, string refrenceId = null!, string commentJsonAttribute = null!, string worklogJsonAttribute = null!)
        {
            using (var db = new AAHREntities())
            {
                /* Fetch the Case */
                Case currentCase = db.Cases.Find(int.Parse(CaseId));
                if (null != currentCase)
                {
                    /* Update Case with new status and Log */
                    UpdateCase(currentCase, null, null);

                    /* Save uploaded documents */
                    //SaveDocuments(currentCase);

                    /* Push changes to db */
                    db.SaveChanges(username);

                    if (!string.IsNullOrEmpty(comment))
                    {
                        //Add CommentDetails against passed Refrence Type
                        if ((!string.IsNullOrEmpty(refrenceId) || refrenceType == ReferenceTypeConstants.CaseLog)
                            && !string.IsNullOrEmpty(refrenceType)
                            && refrenceType != ReferenceTypeConstants.Case)
                        {
                            switch (refrenceType)
                            {
                                case ReferenceTypeConstants.CaseLog:
                                    int caseLogId = currentCase.CaseLogs.LastOrDefault().CaseLogId;
                                    CommentDetails.SaveComment(caseLogId.ToString(), CommentModel.ReferenceType.CaseLog, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.ServiceRequest:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.ServiceRequest, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.Inspection:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.Inspection, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.Violation:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.Violation, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.Notice:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.Notice, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.Contact:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.Contact, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.PropSnapshot:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.PropSnapshot, comment, username, commentJsonAttribute);
                                    break;
                                case ReferenceTypeConstants.GMCheckList:
                                    CommentDetails.SaveComment(refrenceId, CommentModel.ReferenceType.GMCheckList, comment, username, commentJsonAttribute);
                                    break;
                            }
                        }
                        //Add comment against caseId
                        //ComCon.CommentDetails.CommentDetails.SaveComment(Convert.ToString(currentCase.CaseLogs.LastOrDefault().CaseLogID), ComCon.CommentDetails.Models.ReferenceType.CaseLog, comment, username);
                        CommentDetails.SaveComment(Convert.ToString(currentCase.CaseId), CommentModel.ReferenceType.Case, comment, username, commentJsonAttribute);

                    }
                    if (!string.IsNullOrEmpty(workLog))
                    {
                        //ComCon.CommentDetails.CommentDetails.SaveComment(Convert.ToString(currentCase.CaseLogs.LastOrDefault().CaseLogID), ComCon.CommentDetails.Models.ReferenceType.CaseLog, workLog, username, IsWorklog: true);
                        CommentDetails.SaveComment(Convert.ToString(currentCase.CaseId), CommentModel.ReferenceType.Case, workLog, username, worklogJsonAttribute, IsWorklog: true);
                    }

                    /* Send Notification */
                    if (IsNotificationEnable & IsSendNotification)
                    {
                        //Ananth - Commented temporarily
                        //SendNotification ac = new SendNotification();
                        //ac.SendNotificationData(int.Parse(CaseId), this.ActionName, this.NotificationData, this.UserName, this.roles, this.isNotificationToRoles);
                    }
                }
                else
                {
                    //TODO: Handle error with approprate message
                    // and rerouting
                    throw new NotImplementedException();
                }
            }

        }


        /// <summary>
        /// Execute bulk action.
        /// Update Case status based on workflow.
        /// Update Case Log.
        /// To Do : move db.SaveChanges() out of for loop
        /// </summary>
        /// <param name="comment">Optional comment</param>
        /// <param name="workLog">Optional workflow</param>
        public void ExecuteBulkAction(List<int> caseIds, string comment = null, string workLog = null, string username = null)
        {
            using (var db = new AAHREntities())
            {
                foreach (int caseId in caseIds)
                {
                    /* Fetch the Case */
                    Case currentCase = db.Cases.Find(caseId);
                    if (null != currentCase)
                    {
                        /* Update Case with new status and Log */
                        UpdateCase(currentCase, null, null);

                        /* Push changes to db */
                        db.SaveChanges(username);

                        if (!string.IsNullOrEmpty(comment))
                        {
                            CommentDetails.SaveComment(Convert.ToString(currentCase.CaseLogs.LastOrDefault().CaseLogId), CommentModel.ReferenceType.CaseLog, comment, username);
                        }
                        if (!string.IsNullOrEmpty(workLog))
                        {
                            CommentDetails.SaveComment(Convert.ToString(currentCase.CaseLogs.LastOrDefault().CaseLogId), CommentModel.ReferenceType.CaseLog, workLog, username, IsWorklog: true);
                        }
                    }
                    else
                    {
                        //TODO: Handle error with approprate message
                        // and rerouting
                        throw new NotImplementedException();
                    }
                }

            }
        }

        /// <summary>
        /// Update new status for Case.
        /// Add Case Logs.
        /// </summary>
        /// <param name="currentCase"></param>
        private void UpdateCase(Case currentCase, string comment, string workLog)
        {
            /* Create Case Log and store current values */
            CaseLog caseLog = new CaseLog();
            caseLog.Action = this.ActionName;
            caseLog.FromState = currentCase.Status;
            caseLog.LastAssigneeId = currentCase.AssigneeId;
            caseLog.LastAssigneeName = currentCase.AssigneeName;
            caseLog.CaseComment = comment;
            caseLog.WorkLog = workLog;

            /* Update assignee */
            if (!string.IsNullOrEmpty(this.AssigneeId))
            {
                currentCase.AssigneeId = this.AssigneeId;
                currentCase.AssigneeName = this.AssigneeName ?? this.AssigneeId;
            }
            caseLog.NewAssigneeId = currentCase.AssigneeId;
            caseLog.NewAssigneeName = currentCase.AssigneeName;

            /* Get Workflow definition and update case status */
            using (var comconDB = new AAHREntities())
            {
                int wfDefinitionId = Convert.ToInt32(currentCase.CaseType.WfDefinitionId);
                WfDefinition wfDefinition = comconDB?.WfDefinitions?.Find(wfDefinitionId);

                if (null != wfDefinition)
                {
                    //Get Current State of the case
                    //int currentCaseStatusID = wfDefinition.WfStates.FirstOrDefault(m => m.Name == currentCase.Status).Id;

                    ///* Get new destination state */
                    //var action = wfDefinition
                    //                    .WfActions.Where(m => m.Name == this.ActionName && m.SourceStateId == currentCaseStatusID).FirstOrDefault();
                    //var state = action != null ? action.WfStates : null;
                    //currentCase.Status = state != null ? state.Name : currentCase.Status;

                    ///* Update Case log */
                    //caseLog.ToState = currentCase.Status;
                    //this.CaseStatus = currentCase.Status;

                    ///*Get Due Days and IsTask from State table*/
                    //if (action != null)
                    //{
                    //    if (action.SourceStateId != action.DestinationStateId)
                    //    {
                    //        currentCase.MaxStatusDays = state.DueDays;
                    //        currentCase.IsTask = state.IsTask;
                    //        currentCase.StatusModifiedOn = DateOnly.FromDateTime(DateTime.Now);

                    //        //set automatic schedular properties
                    //        currentCase.IsAuto = state.IsAuto;
                    //        currentCase.AutoMaxStatusDays = state.AutoDefaultStatusDays;
                    //        currentCase.AutoNextAction = state.WF_Action2 != null ? state.WF_Action2.Name : null;
                    //        currentCase.AutoStautsModifiedOn = DateTime.Now;
                    //    }
                    //}
                }
                else
                {
                    //TODO: Handle error with approprate message
                    // and rerouting
                    throw new NotImplementedException();
                }
            }

            /* Add Case log to case */
            currentCase.CaseLogs.Add(caseLog);
        }

        /// <summary>
        /// Update Case AutoStatusModifiedOn Date
        /// </summary>
        /// <param name="caseId"></param>
        public void UpdateCaseAutoStatusModifiedOnDt(int caseId, DateTime stautsModifiedOnDt)
        {
            using (var cmsDB = new AAHREntities())
            {
                var currentCase = cmsDB.Cases.Find(caseId);

                if (currentCase.IsAuto)
                {
                    currentCase.AutoStautsModifiedOn = stautsModifiedOnDt;
                    cmsDB.SaveChanges();

                    //Execute stored procedure for immediate auto action
                    cmsDB.Database.ExecuteSqlRaw("SystemAutoActions"); //ExecuteSqlCommand
                }
            }
        }

        /// <summary>
        /// Add Extra Case Log for any particular action
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="actionName"></param>
        /// <param name="comment"></param>
        /// <param name="username"></param>
        /// <param name="newAssigneeID"></param>
        /// <param name="newAssigneeName"></param>
        public static void AddCaseLog(int caseId, string actionName, string comment, string username, string newAssigneeID = "", string newAssigneeName = "")
        {
            using (var db = new AAHREntities())
            {
                /* Fetch the Case */
                Case currentCase = db.Cases.Find(caseId);
                CaseLog caseLog = new CaseLog();
                caseLog.Action = actionName;
                caseLog.FromState = currentCase.Status;
                caseLog.LastAssigneeId = currentCase.AssigneeId;
                caseLog.LastAssigneeName = currentCase.AssigneeName;
                if (!string.IsNullOrEmpty(newAssigneeID) && !string.IsNullOrEmpty(newAssigneeName))
                {
                    caseLog.LastAssigneeId = newAssigneeID;
                    caseLog.LastAssigneeName = newAssigneeName;
                }
                currentCase.CaseLogs.Add(caseLog);
                db.SaveChanges(username);

                if (!string.IsNullOrEmpty(comment))
                {
                    CommentDetails.SaveComment(Convert.ToString(currentCase.CaseLogs.LastOrDefault().CaseLogId), CommentModel.ReferenceType.CaseLog, comment, username);
                }
            }
        }

        #endregion //Execute Action

        #region Send Message to Group
        /// <summary>
        /// Send Message to Group
        /// </summary>
        /// <returns></returns>
        /*Ananth - Commented temporarily public bool SendMessagetoGroup(string Message, NotificationCredential notificationCredential, string RoleMailIds)
        {
            SmtpClient smtp = new System.Net.Mail.SmtpClient();
            var credential = (System.Net.NetworkCredential)smtp.Credentials;

            string[] MailIds = RoleMailIds.Split(',');

            for (int i = 0; i < MailIds.Count(); i++)
            {
                if (MailIds[i] != "")
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(notificationCredential.FromEmailId);
                    mail.To.Add(MailIds[i]);
                    mail.Subject = "Checklist";
                    mail.Body = Message;
                    smtp.Host = notificationCredential.Host;
                    smtp.Port = notificationCredential.Port;
                    if (!string.IsNullOrEmpty(notificationCredential.CredentialName) && !string.IsNullOrEmpty(notificationCredential.CredentialPwd))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(notificationCredential.CredentialName, notificationCredential.CredentialPwd);
                    }
                    else
                    {
                        smtp.Credentials = null;
                    }
                    mail.IsBodyHtml = true;
                    smtp.Send(mail);
                }
            }
            return true;
        }*/
        #endregion

        #region Get MailId's according to Role
        /// <summary>
        /// Get MailId's according to Role
        /// </summary>
        /// <returns></returns>
        public string GetRoleMailId(string Role)
        {
            List<string> roles = new List<string> { Role };
            string rolesString = string.Join(",", roles);
            List<ApplicationUser> usersinRoles = null; //IDMApplicationUser.GetIDMUserByRole(rolesString);

            string RoleMailIds = null;

            for (int i = 0; i < usersinRoles.Count(); i++)
            {
                if (RoleMailIds == null)
                {
                    RoleMailIds = usersinRoles[i].Email;
                }
                else
                {
                    RoleMailIds = RoleMailIds + "," + usersinRoles[i].Email;
                }
            }
            return RoleMailIds;
        }
        #endregion
    }
}
