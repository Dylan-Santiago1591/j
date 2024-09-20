using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.interfaz
{
    public interface ICityController
    {
        Task<IActionResult> Delete(int id);
        Task<ActionResult<CityDto>> GetById(int id);
        Task<ActionResult<City>> Save([FromBody] CityDto cityDto);
        Task<IActionResult> Update([FromBody] CityDto cityDto);
        Task<ActionResult<IEnumerable<CityDto>>> GetAll();

    }
}