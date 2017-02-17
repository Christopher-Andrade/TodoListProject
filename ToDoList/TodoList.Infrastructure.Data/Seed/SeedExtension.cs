using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Data.Context;

namespace TodoList.Infrastructure.Data.Seed
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

            if (!context.Provinces.Any())
            {
                List<Province> listP = new List<Province>();
                listP.Add(new Province()
                {
                    Name = "Gauteng",
                    Cities =
                        new List<City> {new City() {Name = "Bedfordview"},
                        new City() {Name = "Pietretief"}}
                });

                listP.Add(new Province()
                {
                    Name = "Western Cape",
                    Cities =
            new List<City> {new City() {Name = "Clifton"},
                        new City() {Name = "Camps Bay"}}
                });

                listP.Add(new Province()
                {
                    Name = "Freestate",
                    Cities =
            new List<City> {new City() {Name = "Vaal Triangle"},
                        new City() {Name = "Vaal City"}}
                });

                context.AddRange(listP);
            }
            context.SaveChanges();

            if (!context.Events.Any())
            {
                var city = context.Cities.Single(x => x.Name == "Bedfordview");
                var prov = context.Provinces.Single(x => x.Name == "Gauteng");
                context.Attach(city);
                context.Attach(prov);

                List<Event> events = new List<Event>();
                events.Add(new Event()
                {
                    City = city,
                    Description = "Rockstar concert on edge",
                    Name = "Rocking Roll Concert",
                    Province = prov
                });

                context.AddRange(events);
            }

            if (!context.Cities.Any())
            {

            }

            context.SaveChanges();


        }
    }
}
