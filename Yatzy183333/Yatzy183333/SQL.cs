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
        public void addVisits(int vid, int eid)
        {
            string stmt = "insert into visits (visitorid, employeeid) values (@vid, @eid)";

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("@vid", vid);
                    cmd.Parameters.AddWithValue("@eid", eid);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
