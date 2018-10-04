using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;using Npgsql;

namespace Yatzy183333
{
    class SQL
    {
        public Boolean CheckName(string name)
        {
            string stmt = "SELECT name FROM player WHERE name = @name";
            Boolean yes = false;

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string rname = reader.GetString(0);
                            if (rname == name)
                            {
                                yes = true;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return yes;
        }

        public int GetId(string name)
        {
            string stmt = "SELECT player_id FROM player WHERE name = @name";
            int id = 0;
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                }
                conn.Close();
            }
            return id;
        }


        public void MakeGame(int type)
        {
            string stmt = "INSERT INTO game (gametype_id) VALUES (@type)";
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
