using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class ProjectParticipantService : IProjectParticipantService
    {
        #region Constructor

        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly IProjectDetailRepository _projectDetailRepository;

        /// <summary>
        /// ProjectParticipantService
        /// </summary>
        /// <param name="storedProcedureExecutor"></param>
        /// <param name="projectDetailRepository"></param>
        public ProjectParticipantService(IStoredProcedureExecutor storedProcedureExecutor,
            IProjectDetailRepository projectDetailRepository)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _projectDetailRepository = projectDetailRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Project Participants
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="caseId"></param>
        /// <param name="apn"></param>
        /// <returns></returns>
        public async Task<List<ProjectParticipantsModel>> ProjectParticipants(int projectId, int caseId, string apn)
        {
            var projectParticipantsModel = new List<Domain.ProjectDetail.ProjectParticipantsModel>();
            try
            {
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@projectID", Value = projectId },
                    new SqlParameter() { ParameterName = "@caseID", Value = caseId },
                    new SqlParameter() { ParameterName = "@apn", Value = apn },
                };
                using (var dt = await _storedProcedureExecutor.ExecuteStoredProcedureWithDataTableAsync("[AAHR].[uspRoGetAllProjectParticipantsForTPP]", sqlParameters))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        projectParticipantsModel = dt.AsEnumerable()
                        .Select(row => new Domain.ProjectDetail.ProjectParticipantsModel
                        {
                            ContactId = row.Field<int>("ContactID"),
                            ContactIdentifierId = row.Field<int?>("ContactIdentifierID"),
                            ContactName = row.Field<string>("ContactName"),
                            Email = row.Field<string>("Email"),
                            Phone = row.Field<string>("Phone"),
                            FullAddress = row.Field<string>("FullAddress"),
                            ContactType = row.Field<string>("ContactType"),
                            Source = row.Field<string>("Source"),
                            Status = row.Field<string>("Status"),
                            
                            
                        })
                        .ToList();
                    }
                }
                return projectParticipantsModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        #endregion


        #region Private Methods
        #endregion
    }
}
