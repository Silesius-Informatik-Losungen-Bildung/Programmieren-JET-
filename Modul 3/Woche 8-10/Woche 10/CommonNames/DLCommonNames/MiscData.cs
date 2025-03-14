using Microsoft.Data.SqlClient;
using System.Data;
using ConfigCommonNames;
namespace DLCommonNames
{
    public class MiscData
    {
        static MiscData()
        {
            ConnectionString = ClassBase.Config["ConnectionStrings:DefaultConnection"];
        }

        private static string ConnectionString;

        public static bool IsKitNrAllowed(string kitNr, int companyId, int kitTypeId)
        {
            bool isAllowed = false;
            using (var conn = NewSqlConnection())
            using (var command = new SqlCommand("IsKitNrAllowed", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@KitNr", kitNr).SqlDbType = SqlDbType.NVarChar;
                command.Parameters.AddWithValue("@CompanyId", companyId).SqlDbType = SqlDbType.Int;
                command.Parameters.AddWithValue("@KitTypeId", kitTypeId).SqlDbType = SqlDbType.Int;
                conn.Open();

                var sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        isAllowed = (bool)sqlDataReader[0];
                    }
                }
            }
            return isAllowed;
        }

        public static SqlConnection NewSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}