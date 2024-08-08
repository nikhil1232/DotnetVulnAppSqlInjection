using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApplicationforsemgrep.Helpers
{
    public class SqlClient
    {

        public QueryResult Union(string input)
        {

            QueryResult r = new QueryResult();

            if (!string.IsNullOrEmpty(input))
            {
                using (var connection = new SqlConnection(""))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM YourTable WHERE id = " + input;
                    using (var cmd = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var results = new List<dynamic>();
                            while (reader.Read())
                            {
                                r = new QueryResult()
                                {
                                    Name = (string)reader["Name"],
                                    Email = (string)reader["Email"],
                                    Age = reader["Age"].ToString(),
                                    Country = (string)reader["Country"]
                                };
                            }

                            return r;
                        }
                    }
                }
            }

            return r;
        }
    }

    public class QueryResult
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}
