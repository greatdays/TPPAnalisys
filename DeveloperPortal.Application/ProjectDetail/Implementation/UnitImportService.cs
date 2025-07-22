using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Repository.Interface;
using LinqToExcel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class UnitImportService : IUnitImportService
    {
        
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly AAHREntities _context;

        public UnitImportService( IStoredProcedureExecutor storedProcedureExecutor,
            AAHREntities context)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _context = context;
        }
        public async  Task<string> ExportImportResult(DataTable data, string filePath)
        {
            throw new NotImplementedException();
        }

        
        public async Task<DataTable> ExecuteImportUnitInfoAsync(DataSet importData, int caseID, string userName)
        {
            var resultTable = new DataTable();

            // Get EF Core's underlying connection
            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var command = conn.CreateCommand();
            command.CommandText = "AAHPCC.uspImportUnitInformationDetails";
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;

            // Add parameters
            var caseParam = new SqlParameter("@CaseID", SqlDbType.Int) { Value = caseID };
            var userParam = new SqlParameter("@UserName", SqlDbType.VarChar) { Value = userName };

            var unitParam = new SqlParameter("@ImportUnitInformationDetails", SqlDbType.Structured)
            {
                Value = importData.Tables[0],
                TypeName = "[AAHPCC].[ImportUnitInformationDetails]"
            };

            var parkingParam = new SqlParameter("@ImportParkingInformationDetails", SqlDbType.Structured)
            {
                Value = importData.Tables[1],
                TypeName = "[AAHPCC].[ImportParkingInformationDetails]"
            };

            command.Parameters.AddRange(new[] { caseParam, userParam, unitParam, parkingParam });

            // Use SqlDataAdapter to fill a DataTable
            using var adapter = new SqlDataAdapter((SqlCommand)command);
            adapter.Fill(resultTable);

            return resultTable;
        }


        /// <summary>
        /// ReadExcelData
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<DataSet> ReadExcelData(string filePath)
        {
            DataSet ds = new DataSet("UnitInformation");
            var excelFile = new ExcelQueryFactory(filePath);

            if (excelFile.GetWorksheetNames().Any())
            {
                //Read UNit Informations
                var sheetName = "Unit Types,Counts,Distribution";
                var rows = (from a in excelFile.Worksheet(sheetName) select a).ToList();
                if (rows.Any())
                {
                    var dtUnitMatrix = SetUnitMatrixData(rows);
                    ds.Tables.Add(dtUnitMatrix);
                }

                //Read Parking Informations
                sheetName = "Parking Matrix";
                var sheetNameData = (from a in excelFile.Worksheet(sheetName) select a).ToList();
                if (sheetNameData.Any())
                {
                    var dtParkingMatrix = SetParkingMatrixData(excelFile, sheetName, sheetNameData);
                    ds.Tables.Add(dtParkingMatrix);
                }
            }
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 
        public StringBuilder ShowExportDataResult(DataTable data)
        {
            var html = new StringBuilder();

            if (data == null || data.Rows.Count == 0)
            {
                return html.AppendLine("<br/><strong>No data available to display.</strong>");
            }

            html.AppendLine("<br/><br/><strong>Uploaded Data Preview:</strong><br/>");
            html.AppendLine("<table border='1' style='border-collapse:collapse; width:100%; font-family:Arial; font-size:14px;'>");

            // Header
            html.AppendLine("<thead style='background-color:#f2f2f2;'><tr>");
            foreach (DataColumn column in data.Columns)
            {
                html.AppendLine($"<th style='padding:8px;'>{System.Net.WebUtility.HtmlEncode(column.ColumnName)}</th>");
            }
            html.AppendLine("</tr></thead>");

            // Body
            html.AppendLine("<tbody>");
            foreach (DataRow row in data.Rows)
            {
                html.AppendLine("<tr>");
                foreach (var item in row.ItemArray)
                {
                    var cellValue = System.Net.WebUtility.HtmlEncode(item?.ToString() ?? string.Empty);
                    html.AppendLine($"<td style='padding:8px;'>{cellValue}</td>");
                }
                html.AppendLine("</tr>");
            }
            html.AppendLine("</tbody>");
            html.AppendLine("</table>");

            return html;
        }


        #region Private Methods

        /// <summary>
        /// SetParkingMatrixData
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="sheetName"></param>
        /// <param name="sheetNameData"></param>
        /// <returns></returns>
        private static DataTable SetParkingMatrixData(ExcelQueryFactory excelFile, string sheetName, List<Row> sheetNameData)
        {
            DataTable dtParkingMatrix = CreateParkingMatrix();
            if (sheetNameData.Count > 14)
            {
                for (int rowId = 0; rowId < sheetNameData.Count; rowId++)
                {

                    if (sheetNameData[rowId][0] != null && sheetNameData[rowId][0].Value.ToString().Trim() == "ACHP#")
                    {
                        DataRow dr = dtParkingMatrix.NewRow();
                        //dr["ProjectName"] = sheetNameData[rowId][2];
                        //dr["SiteNameAndAddress"] = sheetNameData[++rowId][2];
                        dr["BuildingNameAndAddress"] = sheetNameData[rowId][2];
                        rowId++;//Parking Table
                        rowId++; //Parking header;
                        dr["ParkingAvailableAtbuildingLevel"] = sheetNameData[++rowId][5] == "Yes";

                        dr["ResindentialSpaces"] = sheetNameData[++rowId][5];
                        dr["StandardCommercialSpaces"] = sheetNameData[rowId][12];

                        dr["AccessibleSpaces"] = sheetNameData[++rowId][5];
                        dr["CommercialAccessibleSpaces"] = sheetNameData[rowId][12];

                        dr["VanAccessibleSpaces"] = sheetNameData[++rowId][5];
                        dr["CommercialVanAccessibleSpaces"] = sheetNameData[rowId][12];

                        dr["TotalResidentialParking"] = sheetNameData[++rowId][5];
                        dr["TotalCommercialParking"] = sheetNameData[rowId][12];

                        dr["ResidentialElectricVehicleChargingStations"] = sheetNameData[++rowId][5];
                        dr["CommercialElectricVehicleChargingStations"] = sheetNameData[rowId][12];

                        dr["ElectricVehicleChargingStations"] = sheetNameData[++rowId][5];
                        dr["CommercialVehicleChargingStations"] = sheetNameData[rowId][12];


                        dr["VanAccessibleChargingStations"] = sheetNameData[++rowId][5];
                        dr["CommercialElectricVanAccessibleChargingStation"] = sheetNameData[rowId][12];

                        dr["StandardAccessibleChargingStations"] = sheetNameData[++rowId][5];
                        dr["CommercialElectricStandardAccessibleChargingStation"] = sheetNameData[rowId][12];

                        dr["AmbulatoryChargingStations"] = sheetNameData[++rowId][5];
                        dr["CommercialElectricAmbulatoryChargingStation"] = sheetNameData[rowId][12];

                        dr["TotalNumberofElectricVehicleChargingStations"] = sheetNameData[++rowId][5];
                        dr["TotalNumberofCommercialElectricVehicleChargingStations"] = sheetNameData[rowId][12];

                        dtParkingMatrix.Rows.Add(dr);
                    }

                }

            }
            return dtParkingMatrix;

        }
        /// <summary>
        /// SetUnitMatrixData
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private static DataTable SetUnitMatrixData(List<Row> rows)
        {
            DataTable dtUnit = CreateUnitTable();
            for (int rowId = 1; rowId < rows.Count; rowId++)
            {
                Row item = rows[rowId];
                // Stop if the row is completely blank
                if (item[0] == "" && item[1] == "Total Number of Units")
                {
                    break;
                }
                else
                {
                    int colInd = 1;
                    DataRow dr = dtUnit.NewRow();
                    dr["NumberofUnits"] = Convert.ToString(rowId);
                    var ACHPNo = Convert.ToString(item[colInd++]);
                    var siteNumber = "";
                    var bldg = "";
                    if ((!string.IsNullOrWhiteSpace(ACHPNo) && ACHPNo.Split('-').Length >= 2))
                    {
                        var lastIndexOf = ACHPNo.LastIndexOf("-");
                        siteNumber = ACHPNo.Substring(0, lastIndexOf).Trim();
                        bldg = ACHPNo.Substring(lastIndexOf + 1, ACHPNo.Length - lastIndexOf - 1).Trim();
                    }
                    dr["ACHPNo"] = siteNumber;
                    dr["Bldg"] = bldg;
                    dr["UnitNum"] = Convert.ToString(item[colInd++]);
                    var managersUnit = Convert.ToString(item[colInd++]);
                    dr["UnitType"] = Convert.ToString(item[colInd++]);
                    dr["FloorPlanType"] = Convert.ToString(item[colInd++]);
                    dr["UnitDesignation"] = Convert.ToString(item[colInd++]);
                    dr["AdditionalAccecibility"] = Convert.ToString(item[colInd++]);
                    var isCSA = Convert.ToString(item[colInd++]);
                    var isVCA = Convert.ToString(item[colInd++]);
                    dr["IsCompliant"] = false;

                    if (IsValidRow(dr, managersUnit, isCSA, isVCA))
                    {
                        dr["ManagersUnit"] = managersUnit == "Yes";
                        dr["IsCSA"] = isCSA == "Yes";
                        dr["IsVCA"] = isVCA == "Yes";
                        dtUnit.Rows.Add(dr);
                    }
                }
            }

            return dtUnit;
        }

        /// <summary>
        /// IsValidRow
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="managersUnit"></param>
        /// <param name="isCSA"></param>
        /// <param name="isVCA"></param>
        /// <returns></returns>
        private static bool IsValidRow(DataRow dr, string managersUnit, string isCSA, string isVCA)
        {
            return new[]
            {
                dr["ACHPNo"], dr["Bldg"], dr["UnitNum"],
                dr["UnitType"], dr["FloorPlanType"],
                dr["UnitDesignation"], dr["AdditionalAccecibility"],
                managersUnit, isCSA, isVCA
             }
            .Any(val => !string.IsNullOrWhiteSpace(Convert.ToString(val)));
        }

        /// <summary>
        /// CreateUnitTable
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateUnitTable()
        {
            DataTable dtUnit = new DataTable();
            dtUnit.Columns.Add("NumberofUnits");
            dtUnit.Columns.Add("ACHPNo");
            dtUnit.Columns.Add("Bldg");
            dtUnit.Columns.Add("UnitNum");
            dtUnit.Columns.Add("ManagersUnit");
            dtUnit.Columns.Add("UnitType");
            dtUnit.Columns.Add("FloorPlanType");
            dtUnit.Columns.Add("UnitDesignation");
            dtUnit.Columns.Add("AdditionalAccecibility");
            dtUnit.Columns.Add("IsCompliant");
            dtUnit.Columns.Add("IsCSA");
            dtUnit.Columns.Add("IsVCA");
            return dtUnit;
        }

        /// <summary>
        /// CreateParkingMatrix
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateParkingMatrix()
        {
            DataTable dtParkingMatrix = new DataTable();
            dtParkingMatrix.Columns.Add("ProjectName");
            dtParkingMatrix.Columns.Add("SiteNameAndAddress");
            dtParkingMatrix.Columns.Add("BuildingNameAndAddress");

            dtParkingMatrix.Columns.Add("ParkingAvailableAtbuildingLevel"); ///Will Parking be provided for Each Residential Dwelling Unit ? (Mark "Yes" / "No")

            dtParkingMatrix.Columns.Add("ResindentialSpaces");//Residential Parking
            dtParkingMatrix.Columns.Add("StandardCommercialSpaces"); // Commercial Parking Spaces  
            dtParkingMatrix.Columns.Add("AccessibleSpaces"); //Accessible Parking  
            dtParkingMatrix.Columns.Add("CommercialAccessibleSpaces");//Commercial Accessible Parking Spaces 

            dtParkingMatrix.Columns.Add("VanAccessibleSpaces");//Van Accessible Parking  
            dtParkingMatrix.Columns.Add("CommercialVanAccessibleSpaces");//Commercial Van Accessible Parking Spaces    
            dtParkingMatrix.Columns.Add("TotalResidentialParking");///Total Residential Parking Spaces  
            dtParkingMatrix.Columns.Add("TotalCommercialParking");// Total Commercial Parking Spaces  

            dtParkingMatrix.Columns.Add("ResidentialElectricVehicleChargingStations");//Residential Electric Vehicle Charging Stations  
            dtParkingMatrix.Columns.Add("CommercialElectricVehicleChargingStations");// Commercial Electric Vehicle Charging Stations   
            dtParkingMatrix.Columns.Add("ElectricVehicleChargingStations");//Electric Vehicle Charging Station  
            dtParkingMatrix.Columns.Add("CommercialVehicleChargingStations");// Commercial Vehicle Charging Stations  

            dtParkingMatrix.Columns.Add("VanAccessibleChargingStations");//Van Accessible Charging Station  
            dtParkingMatrix.Columns.Add("CommercialElectricVanAccessibleChargingStation");// Commercial Van Accessible Charging Stations   
            dtParkingMatrix.Columns.Add("StandardAccessibleChargingStations");////Standard Accessible Charging Station 
            dtParkingMatrix.Columns.Add("CommercialElectricStandardAccessibleChargingStation");//  Commercial Standard Accessible Charging Stations  
            dtParkingMatrix.Columns.Add("AmbulatoryChargingStations");//Ambulatory Charging Station  
            dtParkingMatrix.Columns.Add("CommercialElectricAmbulatoryChargingStation");//Commercial Ambulatory Charging Stations    
            dtParkingMatrix.Columns.Add("TotalNumberofElectricVehicleChargingStations");//Total Number of Electric Vehicle Charging Stations    
            dtParkingMatrix.Columns.Add("TotalNumberofCommercialElectricVehicleChargingStations");//Total Number of Commercial Charging Stations

            return dtParkingMatrix;

        }

        #endregion
    }
}
