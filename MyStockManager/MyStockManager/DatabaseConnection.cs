using System;
using Npgsql;
using System.Data.Common;

namespace MyStockManager
{
	public class DatabaseConnection
	{
		private static DatabaseConnection instance;
		private string connectionString;
		private NpgsqlConnection connection;

		public static DatabaseConnection Instance {
			get {
				if (instance == null) {
					instance = new DatabaseConnection ();
				}
				return instance;
			}
		}

		public string ConnectionString {
			get { return connectionString;}
			private set { connectionString = value; }
		}

		public NpgsqlConnection Connection {
			get { return connection; }
			private set { connection = value; }
		}

		private DatabaseConnection ()
		{
			ConnectionString = "Server=127.0.0.1;User Id=postgres;" +
			"Password=postgres;Database=mystorehouse;";
			Connection = new NpgsqlConnection (ConnectionString);
			Connection.Open ();
		}

		~DatabaseConnection() {
			Connection.Close ();
			Connection = null;
		}

		public NpgsqlDataReader getDataReader(string sqlQuery) {
			NpgsqlCommand command = new NpgsqlCommand (sqlQuery, Connection);
			return command.ExecuteReader ();
		}

		public object getValue(string sqlQuery) {
			NpgsqlCommand command = new NpgsqlCommand (sqlQuery, Connection);
			return command.ExecuteScalar ();
		}

		public int executeQuery(string sqlQuery) {
			NpgsqlCommand command = new NpgsqlCommand (sqlQuery, Connection);
			return command.ExecuteNonQuery ();
		}

	}
}

