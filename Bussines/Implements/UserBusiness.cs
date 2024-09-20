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
    public class UserBusiness : IUserBusiness
    {
        protected readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> users = await this.data.GetAll();
            var userDtos = users.Select(user => new UserDto
            {
                id = user.id,
                Username = user.Username,
            });

            return userDtos;
        }


        public async Task<UserDto> GetById(int id)
        {
            User user = await this.data.GetById(id);
            UserDto userDto = new UserDto();

            userDto.id = user.id;
            userDto.Username = user.Username;

            return userDto;
        }

        public User mapearDatos(User user, UserDto entity)
        {
            user.id = entity.id;
            user.Username = entity.Username;

            return user;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user.CreatedAt = DateTime.Now.AddHours(-5);
            user = this.mapearDatos(user, entity);

            return await this.data.Save(user);
        }

        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            user = this.mapearDatos(user, entity);
            await this.data.Update(user);
        }

    }
}