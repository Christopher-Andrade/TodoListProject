using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Services.Interfaces;

namespace TodoList.Services
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
            var res = _provinceRepo.GetByPredicate(x => x.Id == provinceId, y => y.Cities);
            var c = (from City cities in res.Select(x => x.Cities) select cities).AsQueryable();
            return c;
        }
    }
}
