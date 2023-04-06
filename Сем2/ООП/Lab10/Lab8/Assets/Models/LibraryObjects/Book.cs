using Lab8.Assets.Helpers;
using Lab8.Assets.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Lab8.Assets.Models.LibraryObjects
{
    public class Book : IDBTable
    {
        #region Props

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public byte[] Image { get; set; }
        public ImageSource Src 
        { 
            get 
            {
                var img = new BitmapImage();

                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    img = MyConverter.ToImageSource(Image);
                });

                return img;
            } 
        }

        #endregion

        #region Ctors

        public Book() 
        { 
        
        }

        public Book(int id, 
                    string title, 
                    int authorId, 
                    byte[] image)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Image = image;
        }

        #endregion

        #region DB

        public string TableName => "Books";

        public object Get(SqlDataReader sql)
        {
            Book res = new Book();

            res.Id = sql.GetInt32(0);
            res.Title = sql.GetString(1);
            res.AuthorId = sql.GetInt32(2);
            res.Image = sql.GetSqlBinary(3).Value;

            return res;
        }

        public SqlCommand GetInsertSqlCommand(SqlConnection connection)
        {
            string query = $"INSERT { TableName } VALUES (@ID, @TITLE, @AUTHORID, @IMAGE)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@ID", this.Id);
            sqlCommand.Parameters.AddWithValue("@TITLE", this.Title);
            sqlCommand.Parameters.AddWithValue("@AUTHORID", this.AuthorId);
            sqlCommand.Parameters.AddWithValue("@IMAGE", new SqlBinary(this.Image));

            return sqlCommand;
        }

        public SqlCommand GetUpdateSqlCommand(SqlConnection connection)
        {
            string query = $"UPDATE { TableName } SET Title = @TITLE, AuthorId = @AID, Image = @IMAGE WHERE BookId = @ID";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@ID", this.Id);
            sqlCommand.Parameters.AddWithValue("@TITLE", this.Title);
            sqlCommand.Parameters.AddWithValue("@AID", this.AuthorId);
            sqlCommand.Parameters.AddWithValue("@IMAGE", new SqlBinary(this.Image));

            return sqlCommand;
        }

        public SqlCommand GetDropSqlCommand(SqlConnection connection)
        {
            string query = $"DELETE FROM { TableName } WHERE BookId = @ID";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@ID", this.Id);

            return sqlCommand;
        }

        #endregion

        #region Methods 

      

        #endregion

        #region From object

        public override string ToString() => $"Id \t\t${this.Id}\n" +
                                             $"Title \t\t ${this.Title}\n" +
                                             $"Author Id \t\t${this.AuthorId}\n";

        public override bool Equals(object obj) => obj is Book b &&
                                                   this.Title == b.Title &&
                                                   this.AuthorId == b.AuthorId;

        #endregion

    }
}
