using Bussines.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.implements
{
    [ApiController]
    [Route("[Controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleBusiness _moduleBusiness;

        public ModuleController(IModuleBusiness moduloBusiness)
        {
            _moduleBusiness = moduloBusiness;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAll() 
        {
            var result = await _moduleBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetById(int id)
        {
            var result = await _moduleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Module>> Save([FromBody] ModuleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            await _moduleBusiness.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moduleBusiness.Delete(id);
            return NoContent();
        }

    }
}
