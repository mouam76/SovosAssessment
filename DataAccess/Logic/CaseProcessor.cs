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
                if (searchCriteria.Status != null)
                {
                    if (isCompound)
                    {
                        sql += "AND ";
                    }
                    else if (!isCompound)
                    {
                        isCompound = true;
                    }

                    sql += " Status = " + searchCriteria.Status;
                }
                if (searchCriteria.Type != null)
                {
                    if (isCompound)
                    {
                        sql += "AND ";
                    }
                    else if (!isCompound)
                    {
                        isCompound = true;
                    }

                    sql += " Type = " + searchCriteria.Type;
                }
                if (!string.IsNullOrWhiteSpace(searchCriteria.Title))
                {
                    if (isCompound)
                    {
                        sql += "AND ";
                    }
                    else if (!isCompound)
                    {
                        isCompound = true;
                    }

                    sql += " Title like '%" + searchCriteria.Title + "%'";
                }
                if (!string.IsNullOrWhiteSpace(searchCriteria.UserName))
                {
                    if (isCompound)
                    {
                        sql += "AND ";
                    }

                    sql += " UserName like '%" + searchCriteria.UserName + "%'";
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
