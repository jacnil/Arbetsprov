using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Web;

namespace WebSite.TechnicalServices
{
    public class DatabaseManager
    {
        private SqlCeConnection _connection;

        public DatabaseManager(string connectionString) {
            this._connection = new SqlCeConnection(connectionString);
        }

        public void WriteMessageToDatabase(DateTime time, string message) 
        {
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = "INSERT INTO Messages VALUES('" + time + "', '" + message + "')";
            command.Connection = this._connection;

            try 
            {
                this._connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
            
            }
            finally
            {
                this._connection.Close();
            }
        }

        public DataSet GetAllMessages() 
        {
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = "SELECT * FROM Messages";
            command.Connection = this._connection;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(command);
            DataSet messagesSet = new DataSet();

            try
            {
                this._connection.Open();
                adapter.Fill(messagesSet);
            }
            catch (Exception e)
            {

            }
            finally
            {
                this._connection.Close();
            }
            return messagesSet;
        }
    }
}