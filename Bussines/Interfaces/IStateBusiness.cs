using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Interfaces
{
    public interface IStateBusiness
    {
        Task<IEnumerable<StateDto>> GetAll();
        Task<StateDto> GetById(int id);
        Task<State> Save(StateDto entity);
        Task Update(StateDto entity);
        Task Delete(int id);

    }
}