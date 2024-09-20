using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Interfaces
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<ViewDto> GetById(int id);
        Task<View> Save(ViewDto entity);
        Task Update(ViewDto entity);
    }
}
