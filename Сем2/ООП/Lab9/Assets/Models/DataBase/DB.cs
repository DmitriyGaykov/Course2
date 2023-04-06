using Lab8.Assets.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab8.Assets.Models.DataBase
{
    public class DB
    {
        #region Fields

        private readonly string connectionString;
        private readonly SqlConnection connection;

        private bool isOpen = false;

        #endregion

        #region Ctors

        public DB(string connString)
        {
            this.connectionString = connString;
            connection = new SqlConnection(connectionString);

            this.OpenAsync();
        }

        ~DB()
        {
            this.Close();
        }

        #endregion

        #region Methods

        #region Methods | Tables managed

        public IList<T> RecvFromDB<T>(T element) where T : class, IDBTable
        {
            IList<T> list = new List<T>();

            DateTime start = DateTime.Now;
            DateTime end;

            while (!isOpen)
            {
                end = DateTime.Now;

                if((end - start).Minutes == 3)
                {
                    return list;
                }
            }

            SqlCommand command = new SqlCommand($"select * from {element.TableName}", connection);
            SqlDataReader reader = command.ExecuteReader();

            T obj;

            while(reader.Read())
            {
                obj = (T)element.Get(reader);
                list.Add(obj);
            }

            reader.Close();

            return list;
        }

        public void InsertObject(IDBTable obj)
        {
            var command = obj.GetInsertSqlCommand(connection);
            command.ExecuteNonQuery();
        }
        public void UpdateObject(IDBTable obj)
        {
            var command = obj.GetUpdateSqlCommand(connection);
            command.ExecuteNonQuery();
        }

        public void DeleteObject(IDBTable obj)
        {
            var command = obj.GetDropSqlCommand(connection);
            command.ExecuteNonQuery();
        }

        public void ExecuteTransaction(params string[] queries)
        {
            StringBuilder mainQuery = new StringBuilder("");
            SqlCommand command;
            var trans = connection.BeginTransaction();

            foreach(var el in queries)
            {
                mainQuery = mainQuery.Clear();
                mainQuery.Append(el);

                command = new SqlCommand(mainQuery.ToString(), connection, trans);
                command.ExecuteNonQuery();
            }

            trans.Commit();
        }

        #endregion

        #region Methods | Async

        public async void OpenAsync()
        {
            await Task.Run(() => this.Open());
        }

        public async void DeleteObjectAsync(IDBTable obj)
        {
            await Task.Run(() => DeleteObject(obj));
        }

        public async void InsertObjectAsync(IDBTable obj)
        {
            await Task.Run(() => InsertObject(obj));
        }

        public async void UpdateObjectAsync(IDBTable obj)
        {
            await Task.Run(() => UpdateObject(obj));
        }

        public async Task<IList<T>> RecvFromDBAsync<T>(T element) where T : class, IDBTable
        {
            var list = await Task.Run(() => this.RecvFromDB<T>(element));

            if(list is null)
            {
                string error = $"DB | RecvFromDBAsync() | Данный не пришли";
                MessageBox.Show(error);
                throw new Exception(error);
            }

            return list;
        }

        #endregion

        #region Methods | DB methods

        public void Open()
        {
            try
            {
                connection.Open();

                if(connection.State == System.Data.ConnectionState.Open)
                {
                    this.isOpen = true;
                }
            } 
            catch (Exception e)
            {
                string error = $"DB | Open() | {e.Message}";
                MessageBox.Show(error);
                throw new Exception(error);
            }
        }

        public void Close()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }

                this.isOpen = false;
            }
            catch(Exception e)
            {
                string error = $"DB | Close() | {e.Message}";
                //MessageBox.Show(error);
                throw new Exception(error);
            }
        }

        #endregion

        #endregion
    }
}
