using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;
namespace App
{
    public static class SqlExecuter
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\программы\\Hotel\\Hotel\\Domain\\Database.mdf;Integrated Security=True";
        private static SqlConnection Connection = new SqlConnection(connectionString);

        public static DataTable Select(string tableName)
        {
            var query = "SELECT * FROM " + tableName;

            Connection.Close();
            Connection.Open();

            SqlCommand command = new SqlCommand(query, Connection);
            command.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdp.Fill(dt);

            Connection.Close();
            return dt;
        }

        public static void Clear()
        {
            var query = "DROP TABLE Hotel";
            Connection.Open();
            SqlCommand command = new SqlCommand(query, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }

        public static DataTable Execute(string query, string tableName)
        {
            Connection.Open();

            SqlCommand command = new SqlCommand(query, Connection);
            command.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdp.Fill(dt);

            Connection.Close();
            return dt;
        }

        public static void Execute(string query)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(query, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
