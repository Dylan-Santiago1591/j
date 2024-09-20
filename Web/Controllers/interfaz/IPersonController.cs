using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.interfaz
{
    public interface IPersonController
    {
        Task<IActionResult> Delete(int id);
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<Person>> Save([FromBody] PersonDto personDto);
        Task<IActionResult> Update([FromBody] PersonDto personDto);
        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();

    }
}