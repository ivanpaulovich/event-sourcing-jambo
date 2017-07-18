using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Dynamic;
using System.Collections.Generic;

namespace Jambo.Application.Queries
{
    public class BlogQueries : IBlogQueries
    {
        private string _connectionString = string.Empty;

        public BlogQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<dynamic> GetBlogAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"SELECT id, url, rating FROM BLOG WHERE Id=@id", new { id });

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return result;
            }
        }

        public async Task<IEnumerable<dynamic>> GetBlogsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<dynamic>(@"SELECT id, url, rating FROM BLOG");
            }
        }
    }
}
