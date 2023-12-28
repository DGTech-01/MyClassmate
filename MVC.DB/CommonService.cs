using DbExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MVC.DB
{
    public class CommonService : ICommonConnectivity
    {
        #region Variables
        public static string DefaultPage;
        public static string ApplicationTitle;
        public static string ApplicationTitle_Short;
        public static string ApplicationCopyright;
        public static string ApplicationVersion;
        public static string ApplicationDesignedBy;
        public static string ApplicationPath;
       // private static ApplicationDbContext db;
        #endregion


        public CommonService()
        {
            #region Initialize the variables
            ApplicationPath = ConfigurationManager.ConnectionStrings["dbConfig"].ConnectionString;
            // ApplicationPath = ConfigurationManager.ConnectionStrings["DoctorConsult"].ConnectionString; //Set the connection string for the first time
            //ApplicationPath = SchoolDetails.Config.DBConnection; 
            ApplicationVersion = "1.0";
            ApplicationDesignedBy = "JMM Infotech Pvt. Ltd.";
            //db = new ApplicationDbContext();
            #endregion
        }

        public CommonService(string connectionstring)
        {
            ApplicationPath = connectionstring;
            //_sqlConnection.Open();
        }

      //  #region Database Functions
        /// <summary>
        /// Setting up the Database object with entities for DBExtensions
        /// </summary>
      

        private static void OpenDBConnection(ref SqlConnection connection)
        {
            connection = new SqlConnection(ApplicationPath);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            if (connection.State != ConnectionState.Open)
            {
                throw new Exception(string.Format("Connection currently {0} when it should be open.", connection.State));
            }
        }
        public static int ExecuteNonQuery(string sqlStatement)
        {
            int response;
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection();

            try
            {
                #region Create a temporary connection for executing the code
                using (connection = new SqlConnection())
                {
                    //open database connection
                    OpenDBConnection(ref connection);
                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command connection
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = sqlStatement;
                        response = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception Ex)
            {
                // LogErrorInFile("ExecuteNonQuery(1)--" + sqlStatement, Ex);
                throw Ex;
            }
            finally
            {
                if ((cmd != null)) cmd = null;
            }

            return response; //return the response after processing has completed
        }
        public  DataSet ExecuteStoredProcedureDataSet(string spName, SqlParameter[] spParams)
        {
            DataSet dsData = new DataSet();

            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection();

            try
            {
                #region Create a temporary connection for executing the code
                using (connection = new SqlConnection())
                {
                    //open database connection
                    OpenDBConnection(ref connection);
                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command connection
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = spName;
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (spParams != null && spParams.Length > 0)
                            cmd.Parameters.AddRange(spParams);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dsData);
                        connection.Close();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception Ex)
            {
                // LogErrorInFile("ExecuteStoredProcedure(1)--" + spName, Ex);
                throw Ex;
            }
            finally
            {
                if ((cmd != null)) cmd = null;
            }

            return dsData;
        }
        public static int ExecuteInsertQuery(String ProcedureName, SqlParameter[] @params)
        {
            try
            {
                int rowsaffected = 0;

                //SqlConnection sqlCon = new SqlConnection(_connectionString);
                //sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                SqlConnection connection = new SqlConnection();

                using (connection = new SqlConnection())
                {
                    //open database connection
                    OpenDBConnection(ref connection);
                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command connection
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = ProcedureName;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (SqlParameter param in @params)
                        {
                            cmd.Parameters.Add(param);
                        }

                        SqlDataAdapter dtAdapter = new SqlDataAdapter();
                        dtAdapter.InsertCommand = cmd;

                        //rowsaffected = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        rowsaffected = cmd.ExecuteNonQuery();
                        // CloseConnection();

                        return rowsaffected;
                    }
                    #endregion
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //CloseConnection();
                // if ((cmd != null)) cmd = null;
            }
        }


        public int ExecuteInsertQueryReturn(String ProcedureName, SqlParameter[] @params)
        {
            try
            {
                int rowsaffected = 0;

                //SqlConnection sqlCon = new SqlConnection(_connectionString);
                //sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                SqlConnection connection = new SqlConnection();

                using (connection = new SqlConnection())
                {
                    //open database connection
                    OpenDBConnection(ref connection);
                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command connection
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = ProcedureName;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (SqlParameter param in @params)
                        {
                            cmd.Parameters.Add(param);
                        }

                        SqlDataAdapter dtAdapter = new SqlDataAdapter();
                        dtAdapter.InsertCommand = cmd;

                        //rowsaffected = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        rowsaffected = Convert.ToInt32(cmd.ExecuteScalar());
                        // CloseConnection();

                        return rowsaffected;
                    }
                    #endregion
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //CloseConnection();
                // if ((cmd != null)) cmd = null;
            }
        }


        public static DataSet ExecuteStoredProcedure(string spName)
        {
            DataSet dsData = new DataSet();

            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection();

            try
            {
                #region Create a temporary connection for executing the code
                using (connection = new SqlConnection())
                {
                    //open database connection
                    OpenDBConnection(ref connection);
                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command connection
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = spName;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dsData);
                        connection.Close();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception Ex)
            {
                //LogErrorInFile("ExecuteStoredProcedure(1)--" + spName, Ex);
                throw Ex;
            }
            finally
            {
                if ((cmd != null)) cmd = null;
            }

            return dsData;
        }
        public DataTable ExecuteStoredProcedures(string spName, SqlParameter[] spParams)
        {
            DataTable dsData = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection();

            try
            {
                #region Create a temporary connection for executing the code
                using (connection = new SqlConnection())
                {
                    //open database connection
                    OpenDBConnection(ref connection);
                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command connection
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = spName;
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (spParams != null && spParams.Length > 0)
                            cmd.Parameters.AddRange(spParams);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dsData);
                        connection.Close();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception Ex)
            {
                //LogErrorInFile("ExecuteStoredProcedure(1)--" + spName, Ex);
                    throw Ex;
            }
            finally
            {
                if ((cmd != null)) cmd = null;
            }

            return dsData;
        }


      //  #region Returns datatable along with all overloads
        public DataTable GetSpecificData(string tableName)
        {
            return getData("*", tableName, "", null);
        }
        public DataTable GetSpecificData(string columns, string tableName)
        {
            return getData(columns, tableName, "", null);
        }
        public DataTable GetSpecificData(string columns, string tableName,
           string orderBy)
        {
            return getData(columns, tableName, "", null, orderBy);
        }
        public DataTable GetSpecificData(string tableName,
           string whereClause, object[] args)
        {
            return getData("*", tableName, whereClause, args);
        }
        public DataTable GetSpecificData(string columns, string tableName,
           string whereClause, object[] args)
        {
            return getData(columns, tableName, whereClause, args);
        }
        public DataTable GetSpecificData(string columns, string tableName,
           string whereClause, object[] args, string orderBy)
        {
            return getData(columns, tableName, whereClause, args, orderBy);
        }
        private DataTable getData(string columns, string tableName,
            string whereClause, object[] args, string orderBy = "")
        {
            #region Generate the query
            var query = SQL
                        .SELECT(columns)
                        .FROM(tableName);


            if (!string.IsNullOrEmpty(whereClause))
                query.WHERE(whereClause, args);

            if (orderBy.Trim().Length != 0)
                query.ORDER_BY(orderBy);

            #endregion

            string sqlText = (args != null) ? string.Format(query.ToString(), args) : query.ToString();

            return getData(sqlText);
        }

        public DataTable getData(string query)
        {
            int response;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            DataTable functionReturnValue;

            try
            {
                #region Create a temporary connection for executing the code
                using (connection = new SqlConnection())
                {
                    //Open DBConnection
                    OpenDBConnection(ref connection);

                    if (connection == null)
                    {
                        throw new ArgumentNullException("connection");
                    }

                    #region Create a command
                    cmd = new SqlCommand();
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;
                    }
                    #endregion

                    //   Create a data adapter to store the inforamtion
                    adp = new SqlDataAdapter();

                    #region set the return value with a database
                    functionReturnValue = new DataTable();
                    {
                        adp.SelectCommand = cmd;
                        response = adp.Fill(functionReturnValue);
                        adp.Dispose();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception Ex)
            {
                // LogErrorInFile("ReturnTable(1)--" + query, Ex);
                throw Ex;
            }
            finally
            {
                if ((cmd != null)) cmd = null;
                if ((adp != null)) adp = null;
            }

            return functionReturnValue;
        }

        //#endregion
        public bool IsDuplicate(string pTablename, string pChekField, string pChekValue, string pIDField, string pIDValue)
        {
            Boolean ReturnData = false;
            try
            {
                DataTable lDataTable = GetSpecificData("count(" + pChekField + ") as 'RowCount'",
                    pTablename, pChekField + " = '{0}' AND " + pIDField + "!= {1}",
                    new object[] { pChekValue, pIDValue });
                if (lDataTable != null && lDataTable.Rows.Count > 0)
                {
                    if (Convert.ToInt32(lDataTable.Rows[0]["RowCount"]) >= 1)
                    {
                        ReturnData = true;
                    }
                }
                return ReturnData;
            }
            catch (Exception Ex)
            {
                throw Ex;
                // LogErrorInFile("IsDuplicateValueInField", Ex);
            }
            
        }

        public bool CheckExist(string tableName, string columnName, string columnValue)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@TableName", tableName);
            sqlParameters[1] = new SqlParameter("@ColumnName", columnName);
            sqlParameters[2] = new SqlParameter("@ColumnValue", columnValue);
            // SqlParameter[] parameters = { new SqlParameter("@TableName","@ColumnName", "@ColumnValue", TableName,ColumnName,txtEmail.Text ) };
            DataTable dt = ExecuteStoredProcedures("CheckExist", sqlParameters);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
    }
}
