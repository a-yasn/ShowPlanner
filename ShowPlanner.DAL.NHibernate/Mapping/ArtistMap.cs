using FluentNHibernate.Mapping;
using ShowPlanner.Domain;

namespace ShowPlanner.DAL.NHibernate.Mapping
{
    public class ArtistMap : ClassMap<Artist>
    {
        public ArtistMap()
        {
            Table("Artists");
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
