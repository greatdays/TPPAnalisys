using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IUnitImportService
    {
        /// <summary>
        /// ReadExcelData
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<DataSet> ReadExcelData(string filePath);

        /// <summary>
        /// ExecuteImportUnitInfoAsync
        /// </summary>
        /// <param name="importData"></param>
        /// <param name="caseID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<DataTable> ExecuteImportUnitInfoAsync(DataSet importData, int caseID, string userName);

        /// <summary>
        /// ExportImportResult
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<string> ExportImportResult(DataTable data, string filePath);

        /// <summary>
        /// ShowExportDataResult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StringBuilder ShowExportDataResult(DataTable data);
    }
}
