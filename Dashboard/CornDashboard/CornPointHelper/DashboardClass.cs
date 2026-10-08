using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CornPointHelper
{
    public static class DashboardClass
    {
        public static string GetConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["dbConn"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveDashboardinMenu(Int32 intMenuCode, byte[] xmlByteArray)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@intMenuCode", intMenuCode));
                parameters.Add(new SqlParameter("@xmlByteArray", xmlByteArray));
                return SqlHelper.ExecuteNonQuery(GetConnectionString(), "procSaveDashboardinMenu", parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetDashboardMenuInfo(Int32 intMenuCode)
        {
            try
            {
                DataSet dsDashboard;
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@MenuCode", intMenuCode));
                dsDashboard = (DataSet)SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.StoredProcedure, "procMenuDashboard", parameters.ToArray());
                
                return dsDashboard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetDashboardDataSet(String strProcName)
        {
            try
            {
                DataSet dsDashboard;
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@FinancialYearCode", 1));
                parameters.Add(new SqlParameter("@dtFrom", DateTime.Now.Date));
                parameters.Add(new SqlParameter("@dtTo", DateTime.Now.Date));
                parameters.Add(new SqlParameter("@EmployeeCode", 1));
                parameters.Add(new SqlParameter("@CompanyCode", 1));
                return dsDashboard = (DataSet)SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.StoredProcedure, strProcName, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
