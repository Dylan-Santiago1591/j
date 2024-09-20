using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.interfaz
{
    public interface ICountryController
    {
        Task<IActionResult> Delete(int id);
        Task<ActionResult<CountriesDto>> GetById(int id);
        Task<ActionResult<Countries>> Save([FromBody] CountriesDto countriesDto);
        Task<IActionResult> Update([FromBody] CountriesDto countriesDto);
        Task<ActionResult<IEnumerable<CountriesDto>>> GetAll();

    }
}