using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Assets.Models.Strategy
{
    public interface IDBTable
    {
        string TableName { get; }
        object Get(SqlDataReader sql);
        SqlCommand GetInsertSqlCommand(SqlConnection connection);
        SqlCommand GetUpdateSqlCommand(SqlConnection connection);
        SqlCommand GetDropSqlCommand(SqlConnection connection);
    }
}
