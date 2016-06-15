using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;

namespace FlatPlanet.DataLayer
{
    public class DL_FlatPlanet
    {      

        #region CRUD OPERATION LAYER

        public static bool AddData(int Curctr)
        {
            bool result = false;
            try
            {
                String connStr = System.Configuration.ConfigurationSettings.AppSettings["FlatPlaneConnectionString"];

                #region BUILD QUERY

                StringBuilder sqlScript = new StringBuilder();
                sqlScript.Append("insert into flatexam (flatcounter )");
                sqlScript.Append(String.Format("Values({0})",Curctr));
     
                #endregion

                #region EXECUTE QUERY
                using (SqlConnection dbConn = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(sqlScript.ToString(), dbConn);

                    dbConn.Open();
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    dbConn.Close();
                    dbConn.Dispose();
                    result = true;
                }
                #endregion
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int ReadData()
        {
            try
            {
                String connStr = System.Configuration.ConfigurationSettings.AppSettings["FlatPlaneConnectionString"];

                int result = 0;

                #region BUILD QUERY

                StringBuilder sqlScript = new StringBuilder();
                sqlScript.Append("Select * from flatexam");
     
                #endregion

                #region EXECUTE QUERY
                using (SqlConnection dbConn = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(sqlScript.ToString(), dbConn);
                
                    dbConn.Open();
                    command.CommandTimeout = 0;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {                    
                        result = !String.IsNullOrEmpty(reader[0].ToString()) ? reader.GetInt32(0) : 0;
                    }
                    command.Connection.Close();
                    dbConn.Close();
                    dbConn.Dispose();

                }
                #endregion
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}