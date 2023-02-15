using IPAddressMediator.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace IPAddressMediator.Services
{
    public interface IStatisticsService
    {
        List<StatisticsModel> GetStatistics(string[] twoLetterCodes);
    }

    public class StatisticsService : IStatisticsService
    {
        public static string connectionString = "Server=.;Database=IPDb;Trusted_Connection=true;TrustServerCertificate=true;";

        public List<StatisticsModel> GetStatistics(string[] twoLetterCodes)
        {
            var result = new List<StatisticsModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    // We initialize a WHERE clause that will either be filled with the twoLetterCodes array or it will remain null
                    var whereClause = string.Empty;

                    if (twoLetterCodes != null && twoLetterCodes.Any())
                    {
                        var inClause = "";

                        for (int i = 0; i < twoLetterCodes.Length; i++)
                        {
                            var param = "@param" + i;
                            command.Parameters.AddWithValue(param, twoLetterCodes[i]);
                            inClause += param + ",";
                        }
                        inClause = inClause.ToString().Remove(inClause.LastIndexOf(","), 1);
                        Debug.WriteLine(inClause);
                        whereClause = "WHERE TwoLetterCode IN (" + inClause + ")";

                    }

                    //The SQL string we use to get our statistics
                    string sql = "SELECT Name AS CountryName, COUNT(IPAddresses.IP) AS AddressesCount, " +
                         "MAX(UpdatedAt) AS LastAddressUpdated FROM Countries " +
                         "INNER JOIN IPAddresses on Countries.Id = IPAddresses.CountryId " +
                         whereClause +
                         " GROUP BY Name;";

                    command.CommandText = sql;

                    // We open the connection with our Database
                    connection.Open();
                    command.Connection = connection;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new StatisticsModel { CountryName = reader.GetString(0), AddressesCount = reader.GetInt32(1), LastAddressUpdated = reader.GetDateTime(2) });
                        }
                    }
                }
                connection.Close();
            }
            return result;
        }
    }
}
