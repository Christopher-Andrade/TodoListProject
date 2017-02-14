using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Services.Interfaces
{
    public interface IRegionService
    {
        IEnumerable<Province> GetAllProvinces();

        IEnumerable<City> GetAllCities();

        IEnumerable<City> GetCitiesByProvince(int provinceId);
    }
}
