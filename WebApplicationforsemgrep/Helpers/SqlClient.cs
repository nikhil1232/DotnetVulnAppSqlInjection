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
                string connStr = "Some String";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string sqlSelect = "SELECT Name, Email, Age, Country FROM Users WHERE Country = '" + input + "'";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, conn);
                SqlDataReader reader = cmdSelect.ExecuteReader();
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
