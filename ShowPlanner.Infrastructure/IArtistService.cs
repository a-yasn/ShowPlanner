using ShowPlanner.Domain;
using System.Collections.Generic;

namespace ShowPlanner.Infrastructure
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();

        Artist GetById(int id);

        void Update(Artist obj);

        void Delete(Artist obj);
    }
}
