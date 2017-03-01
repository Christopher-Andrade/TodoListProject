using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsEvents.Domain.Entities;
using SportsEvents.Infrastructure.Data.Context;

namespace SportsEvents.Infrastructure.Data.Seed
{
    public static class ProjectContextExtensions
    {
        public static void EnsureSeedData(this ProjectContext context)
        {
            // context.Database.EnsureDeleted();
            context.Database.Migrate();

            var rows = from o in context.Events
                select o;
            foreach (var row in rows)
            {
                context.Events.Remove(row);
            }

            var r2 = from o in context.Provinces
                select o;
            foreach (var row in r2)
            {
                context.Provinces.Remove(row);
            }

            var r3 = from o in context.Cities
                select o;
            foreach (var row in r3)
            {
                context.Cities.Remove(row);
            }


            context.SaveChanges();

            using (var transaction = context.Database.BeginTransaction())
            {

                if (!context.Cities.Any())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Cities] ON");
                    List<City> cities = new List<City>();

                    cities.Add(new City() {Name = "Bedfordview", Id = 1});
                    cities.Add(new City() {Name = "Pietretief", Id = 2});
                    cities.Add(new City() {Name = "Clifton", Id = 3});

                    cities.Add(new City() {Name = "Camps Bay", Id = 4});

                    cities.Add(new City() {Name = "Vaal Triangle", Id = 5});

                    cities.Add(new City() {Name = "Vaal City", Id = 6});

                    context.Cities.AddRange(cities);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Cities] OFF");


                }

                if (!context.Provinces.Any())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Provinces] ON");
                    List<Province> listP = new List<Province>();
                    var city1 = context.Cities.Single(x => x.Name == "Bedfordview");
                    var city2 = context.Cities.Single(x => x.Name == "Pietretief");
                    listP.Add(new Province()
                    {
                        Name = "Gauteng",
                        Cities = new List<City>() {city1, city2},
                        Id = 1
                    });

                    city1 = context.Cities.Single(x => x.Name == "Clifton");
                    city2 = context.Cities.Single(x => x.Name == "Camps Bay");
                    listP.Add(new Province()
                    {
                        Name = "Western Cape",
                        Cities = new List<City>() {city1, city2},
                        Id = 2
                    });

                    city1 = context.Cities.Single(x => x.Name == "Vaal Triangle");
                    city2 = context.Cities.Single(x => x.Name == "Vaal City");
                    listP.Add(new Province()
                    {
                        Name = "Freestate",
                        Cities = new List<City>() {city1, city2},
                        Id = 3
                    });

                    context.AddRange(listP);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Provinces] OFF");
                }


                if (!context.Events.Any())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Events] ON");
                    var city = context.Cities.Single(x => x.Name == "Bedfordview");
                    var prov = context.Provinces.Single(x => x.Name == "Gauteng");
                    context.Attach(city);
                    context.Attach(prov);

                    List<Event> events = new List<Event>
                    {
                        new Event()
                        {
                            City = city,
                            Description = "Rockstar concert on edge",
                            Name = "Rocking Roll Concert",
                            Province = prov,
                            Id = 1
                        }
                    };

                    city = context.Cities.Single(x => x.Name == "Clifton");
                    prov = context.Provinces.Single(x => x.Name == "Western Cape");
                    context.Attach(city);
                    context.Attach(prov);

                    events.Add(
                        new Event()
                        {
                            City = city,
                            Name = "Kasper de Vries Live!",
                            Description = "Kaspers 20 year comeback show",
                            Province = prov,
                            Id = 2
                        }
                    );

                    city = context.Cities.Single(x => x.Name == "Vaal City");
                    prov = context.Provinces.Single(x => x.Name == "Freestate");
                    context.Attach(city);
                    context.Attach(prov);

                    events.Add(
                       new Event()
                       {
                           City = city,
                            Description = "Part of the Bruce Springsteen world tour, feauturing the one and only",
                            Name = "Bruce Springsteen",
                            Province = prov,
                            Id = 3
                        }
                   );

                    context.AddRange(events);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Events] OFF");

                }

                transaction.Commit();
            }

        }
    }
}
    

