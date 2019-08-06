using Dapper;
using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShowPlanner.DAL.Dapper
{
    public class ShowService : IShowService
    {
        private string connectionString;

        public ShowService(IConfigService configService)
        {
            connectionString = configService.ConnectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Delete(Show obj)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.ExecuteScalar<Artist>("DELETE FROM Shows WHERE Id = @id", new { id = obj.Id });
            }
        }

        public IEnumerable<Show> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Show>("SELECT * FROM Shows");
            }
        }

        public Show GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirst<Show>("SELECT * FROM Shows WHERE Id = @id", new { id = id });
            }
        }

        public void Update(Show obj)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();

                if (obj.Id == 0)
                {
                    obj.Id = dbConnection.QuerySingle<int>("INSERT INTO Shows (Name, Description) VALUES (@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)", obj);
                }
                else
                {
                    dbConnection.ExecuteScalar<Show>("UPDATE Shows SET Name= @Name, Description = @Description WHERE Id = @Id", obj);
                }
            }
        }
    }
}
