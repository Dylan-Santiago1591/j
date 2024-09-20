using Data.Interfaces;
using Entity.DTO;

using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.interfaz
{
    public interface IViewController
    {
        Task<IActionResult> Delete(int id);
        Task<ActionResult<ViewDto>> GetById(int id);
        Task<ActionResult<IViewData>> Save([FromBody] ViewDto viewDto);
        Task<IActionResult> Update([FromBody] ViewDto viewDto);
        Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
    }   
}
