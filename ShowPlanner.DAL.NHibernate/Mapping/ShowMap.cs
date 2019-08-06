using FluentNHibernate.Mapping;
using ShowPlanner.Domain;

namespace ShowPlanner.DAL.NHibernate.Mapping
{
    public class ShowMap : ClassMap<Show>
    {
        public ShowMap()
        {
            Table("Shows");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}
