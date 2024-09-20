using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IModuleData
    {
        public Task Delete(int id);
        public Task<Module> GetById(int id);
        public Task<Module> Save(Module entity);
        public Task Update(Module entity);
        public Task<IEnumerable<Module>> GetAll();
        public Task<Module> GetByName(string Description);
    }
}
