using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface IAdhocRepository
    {
        void BeginTransaction();
        void Commit();
        DataSet ExecuteDataSetStoredProcedure(string ProcedureName, SqlParameter[] @params);
        bool ExecuteInsertQuery(string ProcedureName, SqlParameter[] @params);
        bool ExecuteNonQuery(string ProcedureName, SqlParameter[] @params);
        DataTable ExecuteSql(string SqlStatement);
        DataTable ExecuteStoredProcedure(string ProcedureName, SqlParameter[] @params);
        bool ExecuteUpdateQuery(string ProcedureName, SqlParameter[] @params);
        SqlParameter MakeInParams(string paramName, SqlDbType paramType, int size, object obj);
        SqlParameter MakeOutParams(string paramName, SqlDbType paramType, int size);
        void Rollback();
        string strExecuteInsertQuery(string ProcedureName, SqlParameter[] @params);
    }
}
