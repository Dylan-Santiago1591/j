using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IStateData
    {
        Task<State> GetById(int id);
        Task<State> GetByName(string name);
        Task<State> Save(State entity);
        Task Update(State entity);
        Task Delete(int id);
        Task<IEnumerable<State>> GetAll();
        Task<IEnumerable<DataSelectDTO>> GetAllSelect();

    }
}