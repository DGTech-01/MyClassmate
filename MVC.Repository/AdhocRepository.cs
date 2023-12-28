using MVC.Domain.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public class AdhocRepository : IAdhocRepository
    {
      

       
        private SqlConnection _sqlConnection;
        private SqlTransaction _sqlTransaction;
        private SqlCommand _sqlCommand;
        private readonly string _connectionString;

        //private SqlDataAdapter myAdapter;
        //private SqlConnection conn;

        public void BeginTransaction()
        {
            _sqlTransaction = _sqlConnection.BeginTransaction();

        }

        public void Commit()
        {
            _sqlTransaction.Commit();
            _sqlTransaction = null;
            CloseConnection();
        }

        public void Rollback()
        {
            _sqlTransaction.Rollback();
            _sqlTransaction = null;
            CloseConnection();
        }

        public AdhocRepository()
        {
            _connectionString = "";//AppSettings.Config.DBConnection;
            _sqlConnection = new SqlConnection(_connectionString);
            //_sqlConnection.Open();
        }
        public AdhocRepository(string connectionstring)
        {
            _connectionString = connectionstring;
            _sqlConnection = new SqlConnection(connectionstring);
            //_sqlConnection.Open();
        }
        //public AdhocRepository()
        //{
        //    _connectionString = Microsoft.IdentityModel.Protocols.ConfigurationManager.ConnectionStrings["dbConfig"].ConnectionString;
        //    _sqlConnection = new SqlConnection(_connectionString);
        //    // _sqlConnection.Open();

        //    // myAdapter = new SqlDataAdapter();
        //    // conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DocMgmConnection"].ConnectionString);
        //}
        public SqlParameter MakeInParams(string paramName, SqlDbType paramType, int size, object obj)
        {
            return MakeParameter(paramName, paramType, size, ParameterDirection.Input, obj);
        }

        public SqlParameter MakeOutParams(string paramName, SqlDbType paramType, int size)
        {
            return MakeParameter(paramName, paramType, size, ParameterDirection.Output, null);
        }

        private SqlParameter MakeParameter(string paramName, SqlDbType paramType, int size, ParameterDirection paramDirection, object obj)
        {
            SqlParameter sqlParam = null;
            if (size > 0)
            {
                sqlParam = new SqlParameter(paramName, paramType, size);
            }
            else
            {
                sqlParam = new SqlParameter(paramName, paramType);
            }
            sqlParam.Direction = paramDirection;
            if (!(sqlParam.Direction == paramDirection & obj == null))
            {
                sqlParam.Value = obj;
            }
            return sqlParam;
        }

        private void CloseConnection()
        {
            if (_sqlTransaction == null)
            {
                if (_sqlCommand != null)
                {
                    _sqlCommand.Dispose();
                    _sqlCommand.Connection.Close();


                }

            }
        }

        private SqlCommand GetCommand()
        {
            //SqlConnection sqlCon = new SqlConnection(_connectionString);
            //sqlCon.Open();

            if (_sqlCommand == null || _sqlCommand != null)
            {
                _sqlCommand = new SqlCommand();
            }
            _sqlCommand.Connection = _sqlConnection;
            if (_sqlTransaction != null)
            {
                _sqlCommand.Transaction = _sqlTransaction;
            }
            _sqlCommand.CommandTimeout = 500;
            return _sqlCommand;
        }

        public DataTable ExecuteSql(string SqlStatement)
        {
            SqlCommand sqlCommand = GetCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = SqlStatement;

            SqlDataAdapter dtAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dtAdapter.Fill(dataTable);

            CloseConnection();
            return dataTable;
        }

        public DataTable ExecuteStoredProcedure(string ProcedureName, SqlParameter[] @params)
        {
            SqlCommand sqlCommand = GetCommand();
            sqlCommand.CommandText = ProcedureName;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (SqlParameter param in @params)
            {
                sqlCommand.Parameters.Add(param);
            }

            SqlDataAdapter dtAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dtObject = new DataTable();
            dtAdapter.Fill(dtObject);

            CloseConnection();

            return dtObject;


            //sqlCommand.Dispose();
            //sqlCommand.Connection.Close();
        }

        public DataSet ExecuteDataSetStoredProcedure(string ProcedureName, SqlParameter[] @params)
        {

            SqlCommand sqlCommand = GetCommand();
            sqlCommand.CommandText = ProcedureName;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (SqlParameter param in @params)
            {
                sqlCommand.Parameters.Add(param);
            }

            SqlDataAdapter dtAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dtObject = new DataSet();
            dtAdapter.Fill(dtObject);

            CloseConnection();

            return dtObject;
        }

        public bool ExecuteInsertQuery(String ProcedureName, SqlParameter[] @params)
        {
            try
            {
                int rowsaffected = 0;

                //SqlConnection sqlCon = new SqlConnection(_connectionString);
                //sqlCon.Open();


                SqlCommand sqlCommand = GetCommand();
                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = ProcedureName;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter param in @params)
                {
                    sqlCommand.Parameters.Add(param);
                }

                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                dtAdapter.InsertCommand = sqlCommand;

                //rowsaffected = Convert.ToInt32(sqlCommand.ExecuteScalar());
                rowsaffected = sqlCommand.ExecuteNonQuery();
                // CloseConnection();

                if (rowsaffected > 0)
                { return true; }
                else { return false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string strExecuteInsertQuery(String ProcedureName, SqlParameter[] @params)
        {
            try
            {
                string rowsaffected = "FAILED";

                SqlCommand sqlCommand = GetCommand();
                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = ProcedureName;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter param in @params)
                {
                    sqlCommand.Parameters.Add(param);
                }

                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                dtAdapter.InsertCommand = sqlCommand;

                rowsaffected = sqlCommand.ExecuteScalar().ToString();
                return rowsaffected;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ExecuteNonQuery(String ProcedureName, SqlParameter[] @params)
        {
            try
            {
                int rowsaffected = 0;

                //SqlConnection sqlCon = new SqlConnection(_connectionString);
                //sqlCon.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = openConnection();
                sqlCommand.CommandText = ProcedureName;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter param in @params)
                {
                    sqlCommand.Parameters.Add(param);
                }

                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                dtAdapter.InsertCommand = sqlCommand;

                rowsaffected = sqlCommand.ExecuteNonQuery();
                // CloseConnection();

                if (rowsaffected > 0)
                { return true; }
                else { return false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ExecuteUpdateQuery(String ProcedureName, SqlParameter[] @params)
        {
            int rowsaffected;

            SqlCommand sqlCommand = GetCommand();
            sqlCommand.Connection = openConnection();
            sqlCommand.CommandText = ProcedureName;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (SqlParameter param in @params)
            {
                sqlCommand.Parameters.Add(param);
            }

            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            dtAdapter.UpdateCommand = sqlCommand;


            rowsaffected = sqlCommand.ExecuteNonQuery();

            CloseConnection();

            if (rowsaffected > 0)
            { return true; }
            else { return false; }
        }

        private SqlConnection openConnection()
        {
            if (_sqlConnection.State == ConnectionState.Closed || _sqlConnection.State == ConnectionState.Broken)
            {
                _sqlConnection.Open();
            }
            return _sqlConnection;
        }


    }
}
