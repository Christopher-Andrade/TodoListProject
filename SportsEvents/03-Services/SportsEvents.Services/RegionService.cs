using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvents.Domain.Entities;
using SportsEvents.Domain.Interfaces;
using SportsEvents.Services.Interfaces;

namespace SportsEvents.Services
{
    public class RegionService : IRegionService
    {
        private readonly IGenericRepository<City> _cityRepo;
        private readonly IGenericRepository<Province> _provinceRepo;

        public RegionService(IGenericRepository<City> cityRepo, IGenericRepository<Province> provinceRepo)
        {
            _cityRepo = cityRepo;
            _provinceRepo = provinceRepo;
        }
        public IEnumerable<Province> GetAllProvinces()
        {
            return _provinceRepo.GetAll();
        }

        public IEnumerable<City> GetAllCities()
        {
            return _cityRepo.GetAll();
        }

        public IEnumerable<City> GetCitiesByProvince(int provinceId)
        {
            if (provinceId < 1) return null;
            var province = _provinceRepo.GetByPredicate(x => x.Id == provinceId, y => y.Cities).ToList();

            var cities = (from p in province
                       select p
                into c
                from city in c.Cities
                select city).ToList();

            return cities;
        }
    }
}
