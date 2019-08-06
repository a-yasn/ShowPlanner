using Microsoft.Extensions.DependencyInjection;
using ShowPlanner.DAL.Dapper;
using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System;
using System.Linq;

namespace ShowPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfigService, ConfigService>()
                .AddSingleton<IArtistService, ShowPlanner.DAL.Dapper.ArtistService>()
                .AddSingleton<IShowService, ShowPlanner.DAL.Dapper.ShowService>()
                //.AddSingleton<IArtistService, ShowPlanner.DAL.NHibernate.ArtistService>()
                //.AddSingleton<IShowService, ShowPlanner.DAL.NHibernate.ShowService>()
                //.AddSingleton<IArtistService, ShowPlanner.DAL.Entity.ArtistService>()
                //.AddSingleton<IShowService, ShowPlanner.DAL.Entity.ShowService>()
                .BuildServiceProvider();

            DoArtistWork(serviceProvider);
            DoShowWork(serviceProvider);
        }

        private static void DoArtistWork(ServiceProvider serviceProvider)
        {
            var artistService = serviceProvider.GetService<IArtistService>();

            artistService.GetAll().ToList().ForEach(x => Console.WriteLine(x));

            var obj = new Artist { FirstName = "Michael", LastName = "Jackson" };

            artistService.Update(obj);

            artistService.GetAll().ToList().ForEach(x => Console.WriteLine(x));

            obj.LastName += " the First";

            artistService.Update(obj);

            artistService.GetAll().ToList().ForEach(x => Console.WriteLine(x));

            artistService.Delete(obj);

            artistService.GetAll().ToList().ForEach(x => Console.WriteLine(x));
        }

        private static void DoShowWork(ServiceProvider serviceProvider)
        {
            var showService = serviceProvider.GetService<IShowService>();

            showService.GetAll().ToList().ForEach(x => Console.WriteLine(x));

            var obj = new Show { Name = "The greatest", Description = "The greatest songs..." };

            showService.Update(obj);

            showService.GetAll().ToList().ForEach(x => Console.WriteLine(x));

            obj.Name += "!!!";

            showService.Update(obj);

            showService.GetAll().ToList().ForEach(x => Console.WriteLine(x));

            showService.Delete(obj);

            showService.GetAll().ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
