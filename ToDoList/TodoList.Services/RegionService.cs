using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    public class RegionService : IRegionService
    {
        public IEnumerable<Province> GetAllProvinces()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetCitiesByProvince(int provinceId)
        {
            throw new NotImplementedException();
        }
    }
}
