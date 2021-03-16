using DataAccess.DataAccess;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Logic
{
    public static class CaseProcessor
    {
        public static List<CaseModel> LoadCases(CaseModel searchCriteria)
        {
            string sql = "";

            if (searchCriteria.ValidSearch())
            {
                bool isCompound = false;

                sql += @"SELECT * FROM DBO.DASHBOARD WHERE ";
                if (searchCriteria.DateStart != null || searchCriteria.DateCreated != null)
                {
                    if (searchCriteria.DateStart != null && searchCriteria.DateEnd != null)
                    {
                        sql += "DateCreated >= " + "'" + searchCriteria.DateStart + "' and DateCreated <= '" + searchCriteria.DateEnd + "'";
                    }
                    else if (searchCriteria.DateStart != null && searchCriteria.DateEnd == null)
                    {
                        sql += "DateCreated >= " + "'" + searchCriteria.DateStart + "'";
                    }
                    else if (searchCriteria.DateStart == null && searchCriteria.DateEnd != null)
                    {
                        sql += "DateCreated <= '" + searchCriteria.DateEnd + "'";
                    }

                    isCompound = true;
                }
                if (isCompound && searchCriteria.Status != null)
                {
                    sql += "AND Status = " + searchCriteria.Status;
                }
                else if (searchCriteria.Status != null)
                {
                    sql += "Status = " + searchCriteria.Status;
                    isCompound = true;
                }
                if ( isCompound && searchCriteria.Type != null)
                {
                    sql += "AND Type = " + searchCriteria.Type;
                }
                else if (searchCriteria.Type != null)
                {
                    sql += "Type = " + searchCriteria.Type;
                    isCompound = true;
                }
                if (isCompound && !string.IsNullOrWhiteSpace(searchCriteria.Title))
                {
                    sql += "AND Title like '%" + searchCriteria.Title + "%'" ;
                }
                else if (!string.IsNullOrWhiteSpace(searchCriteria.Title))
                {
                    sql += "Title like '%" + searchCriteria.Title + "%'";
                    isCompound = true;
                }
                if (isCompound && !string.IsNullOrWhiteSpace(searchCriteria.UserName))
                {
                    sql += "AND UserName like '%" + searchCriteria.UserName + "%'";
                }
                else if (!string.IsNullOrWhiteSpace(searchCriteria.UserName))
                {
                    sql += "UserName like '%" + searchCriteria.UserName + "%'";
                }

                sql += ";";
            }
            else
            {
                List<CaseModel> emptyList = new List<CaseModel>();
                return emptyList;
            }

            return SQLDataAccess.LoadData<CaseModel>(sql);
        }
    }
}
