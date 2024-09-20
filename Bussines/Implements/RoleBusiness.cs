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
    public class RoleBusiness : IRoleBusiness
    {
        protected readonly IRoleData data;

        public RoleBusiness(IRoleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            IEnumerable<Role> roles = await this.data.GetAll();
            var roleDtos = roles.Select(role => new RoleDto
            {
                id = role.id,
                Name = role.Name,
                Description = role.Description
            });

            return roleDtos;
        }

        public async Task<RoleDto> GetById(int id)
        {
            Role role = await this.data.GetById(id);
            RoleDto roleDto = new RoleDto();

            roleDto.id = role.id;
            roleDto.Name = role.Name;
            roleDto.Description = role.Description;

            return roleDto;
        }

        public Role mapearDatos(Role role, RoleDto entity)
        {
            role.id = entity.id;
            role.Name = entity.Name;
            role.Description = entity.Description;

            return role;
        }

        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role.CreatedAt = DateTime.Now.AddHours(-5);
            role = this.mapearDatos(role, entity);

            return await this.data.Save(role);
        }

        public async Task Update(RoleDto entity)
        {
            Role role = await this.data.GetById(entity.id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }

            role = this.mapearDatos(role, entity);
            await this.data.Update(role);
        }
    }
}