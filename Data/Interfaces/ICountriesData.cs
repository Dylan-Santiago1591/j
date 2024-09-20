using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICountriesData
    {
        Task<Countries> GetById(int id);
        Task<Countries> GetByName(string name);
        Task<Countries> Save(Countries entity);
        Task Update(Countries entity);
        Task Delete(int id);
        Task<IEnumerable<Countries>> GetAll();
        Task<IEnumerable<DataSelectDTO>> GetAllSelect();

    }
}