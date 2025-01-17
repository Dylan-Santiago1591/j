using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.interfaz
{
    public interface IRoleViewController
    {
        Task<IActionResult> Delete(int id);
        Task<ActionResult<RoleViewDto>> GetById(int id);
        Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleViewDto);
        Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto);
        Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();

    }
}