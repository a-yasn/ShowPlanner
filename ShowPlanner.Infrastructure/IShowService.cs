using ShowPlanner.Domain;
using System.Collections.Generic;

namespace ShowPlanner.Infrastructure
{
    public interface IShowService
    {
        IEnumerable<Show> GetAll();

        Show GetById(int id);

        void Update(Show obj);

        void Delete(Show obj);
    }
}
