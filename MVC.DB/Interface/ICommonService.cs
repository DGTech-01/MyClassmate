using System.Data;
using System.Data.SqlClient;

namespace MVC.DB
{
    public interface ICommonConnectivity
    {
        DataTable ExecuteStoredProcedures(string spName, SqlParameter[] spParams);
        DataTable getData(string query);
        DataTable GetSpecificData(string tableName);
        DataTable GetSpecificData(string columns, string tableName);
        DataTable GetSpecificData(string tableName, string whereClause, object[] args);
        DataTable GetSpecificData(string columns, string tableName, string orderBy);
        DataTable GetSpecificData(string columns, string tableName, string whereClause, object[] args);
        DataTable GetSpecificData(string columns, string tableName, string whereClause, object[] args, string orderBy);
        //T GetSpecificEntity<T>(string columns, string tableName) where T : BaseEntity;
        //T GetSpecificEntity<T>(string tableName, string whereClause, object[] args) where T : BaseEntity;
        //T GetSpecificEntity<T>(string columns, string tableName, string whereClause, object[] args) where T : BaseEntity;
        //T SpecificEntity<T>(string tableName) where T : BaseEntity;
        bool IsDuplicate(string pTablename, string pChekField, string pChekValue, string pIDField, string pIDValue);
        bool CheckExist(string tableName, string columnName, string columnValue);
    }
}