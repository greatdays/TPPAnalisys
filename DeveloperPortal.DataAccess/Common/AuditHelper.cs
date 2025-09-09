using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Common
{
    public static class AuditHelper
    {
        public static void ApplyAudit(object entity, EntityState state, string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return;

            var entityType = entity.GetType();
            var now = DateTime.UtcNow;

            var createdOn = entityType.GetProperty("CreatedOn");
            var createdBy = entityType.GetProperty("CreatedBy");
            var modifiedOn = entityType.GetProperty("ModifiedOn");
            var modifiedBy = entityType.GetProperty("ModifiedBy");

            if (state == EntityState.Added)
            {
                createdOn?.SetValue(entity, now);
                createdBy?.SetValue(entity, username);
            }

            if (state == EntityState.Added || state == EntityState.Modified)
            {
                modifiedOn?.SetValue(entity, now);
                modifiedBy?.SetValue(entity, username);
            }
        }
        #region Extension Methods

        /// <summary>
        /// Convert DataTable to List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns>List of Type T</returns>
        public static List<T> ConvertDataTable<T>(this DataTable dt) where T : class
        {
            List<T> data = new List<T>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
            }
            return data;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// GetItem
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns>Retrun t type</returns>
        private static T GetItem<T>(DataRow dataRow)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dataRow[column.ColumnName] != DBNull.Value)
                        {
                            pro.SetValue(obj, dataRow[column.ColumnName], null);
                        }
                        break;
                    }
                }
            }
            return obj;
        }

        #endregion
    }
}
