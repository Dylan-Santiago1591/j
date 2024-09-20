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
    public class UserRoleBusiness : IUserRoleBusiness
    {
        protected readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRole> UserRoles = await this.data.GetAll();
            var UserRoleDtos = UserRoles.Select(view => new UserRoleDto
            {
                id = view.id
            });

            return UserRoleDtos;
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userRole = await this.data.GetById(id);
            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.id = userRoleDto.id;

            return userRoleDto;
        }

        public UserRole mapearDatos(UserRole userRole, UserRoleDto entity)
        {
            userRole.id = entity.id;

            return userRole;
        }

        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole();
            userRole.CreatedAt = DateTime.Now.AddHours(-5);
            userRole = this.mapearDatos(userRole, entity);
            userRole.IdRole = null;
            userRole.IdUser = null;

            return await this.data.Save(userRole);
        }

        public async Task Update(UserRoleDto entity)
        {
            UserRole userRole = await this.data.GetById(entity.id);
            if (userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }

            userRole = this.mapearDatos(userRole, entity);
            await this.data.Update(userRole);
        }

    }
}