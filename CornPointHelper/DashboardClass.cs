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
                parameters.Add(new SqlParameter("@intMODULE_ID", 150));
                parameters.Add(new SqlParameter("@vbrFile", xmlByteArray));
                return SqlHelper.ExecuteNonQuery(GetConnectionString(), "uspUpdateDashboardFile", parameters.ToArray());
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
                parameters.Add(new SqlParameter("@intMODULE_ID", 150));
                dsDashboard = (DataSet)SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.StoredProcedure, "uspGetDashboardFile", parameters.ToArray());

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
                parameters.Add(new SqlParameter("@TYPEID", 1));
                parameters.Add(new SqlParameter("@USER_ID", 1));
                parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", 1));
                parameters.Add(new SqlParameter("@DATE", DBNull.Value));
                return dsDashboard = (DataSet)SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.StoredProcedure, strProcName, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
