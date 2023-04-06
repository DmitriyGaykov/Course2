using Lab8.Assets.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Assets.Models.LibraryObjects
{
    public class Author : IDBTable
    {
        #region Props

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }

        #endregion

        #region Ctors

        public Author()
        {

        }

        public Author(int id,
                      string fullName,
                      string alias)
        {
            Id = id;
            FullName = fullName;
            Alias = alias;
        }

        #endregion

        #region DB

        public string TableName => "Authors";

        public object Get(SqlDataReader sql)
        {
            Author res = new Author();

            res.Id = sql.GetInt32(0);
            res.FullName = sql.GetString(1);
            res.Alias = sql.GetString(2);

            return res;
        }

        public SqlCommand GetInsertSqlCommand(SqlConnection connection)
        {
            string query = $"INSERT {TableName} VALUES (@ID, @FULLNAME, @ALIAS)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@ID", this.Id);
            sqlCommand.Parameters.AddWithValue("@FULLNAME", this.FullName);
            sqlCommand.Parameters.AddWithValue("@ALIAS", this.Alias);

            return sqlCommand;
        }

        public SqlCommand GetUpdateSqlCommand(SqlConnection connection)
        {
            string query = $"UPDATE { TableName } SET FullName = @FULLNAME, Alias = @ALIAS WHERE AuthorId = @ID";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@ID", this.Id);
            sqlCommand.Parameters.AddWithValue("@FULLNAME", this.FullName);
            sqlCommand.Parameters.AddWithValue("@ALIAS", this.Alias);

            return sqlCommand;
        }

        public SqlCommand GetDropSqlCommand(SqlConnection connection)
        {
            string query = $"DELETE FROM { TableName } WHERE AuthorId = @ID";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@ID", this.Id);

            return sqlCommand;
        }

        #endregion

        #region From object

        public override string ToString() => $"Id \t\t${this.Id}\n" +
                                             $"Full Name \t\t ${this.FullName}\n" +
                                             $"Alias \t\t${this.Alias}\n";

        public override bool Equals(object obj) => obj is Author a &&
                                                   a.FullName == this.FullName &&
                                                   a.Alias == this.Alias;

        #endregion
    }

}
