using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;


namespace Yatzy183333
{
    public class SQL
    {
        public int poäng { get; set; }
        public string namn { get; set; }
        public string smeknamn { get; set; }
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
 

        public int GetMatchId()
        {
            string stmt = "SELECT MAX(game_id) FROM game";
            int id = 0;
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
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

        public void EndGame(int matchid)
        {
            string stmt = "UPDATE game SET ended_at = now() WHERE game_id = @matchid";
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@matchid", matchid);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void EndPlayer(int pid, int score, int id)
        {
            string stmt = "INSERT INTO game_player(game_id, player_id, score) VALUES (@id, @pid, @score)";
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void AddPlayer(string name, string nick)
        {
            string stmt = "INSERT INTO player (name, nickname) VALUES (@name, @nick)";
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@nick", nick);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<SQL> GetHighScore(int type)
        {
            string stmt = "SELECT game_player.score, player.name, player.nickname FROM game_player INNER JOIN player ON player.player_id = game_player.player_id INNER JOIN game ON game.game_id = game_player.game_id WHERE game_player.score IS NOT NULL AND game.gametype_id = @type order by score desc limit 5";
            List<SQL> HighScore = new List<SQL>();
            SQL s;
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = stmt;
                    cmd.Parameters.AddWithValue("@type", type);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s = new SQL()
                            {
                                poäng = reader.GetInt32(0),
                                namn = reader.GetString(1),
                                smeknamn = reader.GetString(2)
                            };
                            HighScore.Add(s);
                        }
                    }
                }
                conn.Close();
            }
            return HighScore;
        }
    }
}
