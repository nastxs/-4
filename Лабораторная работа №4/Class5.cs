using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Npgsql;
using System;


namespace Лабораторная_работа__4
{
     class Class5
    {
        public static NpgsqlConnection Connect(string connectionString)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error connecting to the database", e);
            }
            return conn;

        }

        public static async Task ExecuteSelectAsJson(NpgsqlConnection conn, string sql, Action<string> callback)
        {
            try
            {

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    var result = await command.ExecuteScalarAsync();
                    if (result is string json)
                    {
                        callback(json);
                    }
                }
            }
            catch (Exception e)
            {
            }
            string connectionString = "Server=localhost; Port=5432; Database=postgres;  Password=фыв123; ";
            
        }

    }
}
