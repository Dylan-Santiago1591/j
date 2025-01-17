using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public class CountriesBusiness : ICountriesBusiness
    {
        protected readonly ICountriesData data;

        public CountriesBusiness(ICountriesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<CountriesDto>> GetAll()
        {
            IEnumerable<Countries> countries = await this.data.GetAll();
            var countriesDto = countries.Select(countries => new CountriesDto
            {
                id = countries.id,
                Name = countries.Name,
            });

            return countriesDto;
        }

        public async Task<CountriesDto> GetById(int id)
        {
            Countries country = await this.data.GetById(id);
            CountriesDto countryDto = new CountriesDto
            {
                id = country.id,
                Name = country.Name,
            };
            return countryDto;
        }

        public Countries mapearDatos(Countries country, CountriesDto entity)
        {
            country.id = entity.id;
            country.Name = entity.Name;
            return country;
        }

        public async Task<Countries> Save(CountriesDto entity)
        {
            Countries country = new Countries
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            country = this.mapearDatos(country, entity);

            return await this.data.Save(country);
        }

        public async Task Update(CountriesDto entity)
        {
            Countries country = await this.data.GetById(entity.id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }

            country = this.mapearDatos(country, entity);
            await this.data.Update(country);
        }


    }
}