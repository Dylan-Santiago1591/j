using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Interfaces
{
    public interface ICountriesBusiness
    {
        Task<IEnumerable<CountriesDto>> GetAll();
        Task<CountriesDto> GetById(int id);
        Task<Countries> Save(CountriesDto entity);
        Task Update(CountriesDto entity);
        Task Delete(int id);

    }
}