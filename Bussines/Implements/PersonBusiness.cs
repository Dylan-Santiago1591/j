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
    public class PersonBusiness : IPersonBusiness
    {
        protected readonly IPersonData data;

        public PersonBusiness(IPersonData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<Person> people = await this.data.GetAll();
            var personDtos = people.Select(person => new PersonDto
            {
                id = person.id,
                First_name = person.First_name,
                Email = person.Email,
                Document = person.Document,
            });

            return personDtos;
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await this.data.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.id = person.id;
            personDto.First_name = person.First_name;
            personDto.Email = person.Email;
            personDto.Document = person.Document;

            return personDto;
        }

        public Person mapearDatos(Person person, PersonDto entity)
        {
            person.id = entity.id;
            person.First_name = entity.First_name;
            person.Email = entity.Email;
            person.Document = entity.Document;

            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person.CreatedAt = DateTime.Now.AddHours(-5);
            person = this.mapearDatos(person, entity);

            return await this.data.Save(person);
        }

        public async Task Update(PersonDto entity)
        {
            Person person = await this.data.GetById(entity.id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }

            person = this.mapearDatos(person, entity);
            await this.data.Update(person);
        }

    }
}