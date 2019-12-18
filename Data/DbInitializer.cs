using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarsManager.Models;

namespace CarsManager.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<CarsContext>())
                {
                    // context.Database.Migrate();
                    
                    if (context.Cars.Any())
                    {
                        return;   // DB has been seeded
                    }

                    var cars = new Car[]
                    {
                        new Car { Manufacture="BMW", Model = "Z55", Engine=3000, ProductionDate = DateTime.Parse("2012-09-01") },
                        new Car { Manufacture="BMW", Model = "Z7", Engine=3500, ProductionDate = DateTime.Parse("2015-09-01") },
                        new Car { Manufacture="BMW", Model = "m3", Engine=2500, ProductionDate = DateTime.Parse("2017-09-01") },
                    };

                    foreach (Car cc in cars)
                    {
                        context.Cars.Add(cc);
                    }
                    context.SaveChanges();

                }
            }
        }
    }
}