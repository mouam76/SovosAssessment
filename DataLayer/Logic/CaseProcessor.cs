using DataAccessLayer.DataAccess;
using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Logic
{
    public static class CaseProcessor
    {
        public static List<CaseModel> LoadCases()
        {
            string sql = @"SELECT * FROM DBO.DASHBOARD;";

            return SQLDataAccess.LoadData<CaseModel>(sql);
        }
    }
}
