using Dapper;
using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShowPlanner.DAL.Dapper
{
    public class ArtistService : IArtistService
    {
        private string connectionString;

        public ArtistService(IConfigService configService)
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

        public void Delete(Artist obj)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.ExecuteScalar<Artist>("DELETE FROM Artists WHERE Id = @id", new { id = obj.Id });
            }
        }

        public IEnumerable<Artist> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Artist>("SELECT * FROM Artists");
            }
        }

        public Artist GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirst<Artist>("SELECT * FROM Artists WHERE Id = @id", new { id = id });
            }
        }

        public void Update(Artist obj)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();

                if (obj.Id == 0)
                {
                    obj.Id = dbConnection.QuerySingle<int>("INSERT INTO Artists (FirstName, LastName) VALUES (@FirstName, @LastName); SELECT CAST(SCOPE_IDENTITY() as int)", obj);
                }
                else
                {
                    dbConnection.ExecuteScalar<Artist>("UPDATE Artists SET FirstName= @FirstName, LastName = @LastName WHERE Id = @Id", obj);
                }
            }
        }
    }
}
