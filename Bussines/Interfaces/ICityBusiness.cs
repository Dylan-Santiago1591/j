using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Interfaces
{
    public interface ICityBusiness
    {
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDto> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(CityDto entity);
        Task Delete(int id);


    }
}