using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public UserRoleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("Registro no encontrado");

            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.UserRoles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM UserRole WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<UserRole>(sql, new { Id = id });
        }

        public async Task<UserRole> Save(UserRole entity)
        {
            context.UserRoles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(UserRole entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<UserRole> GetByName(int id)
        {
            return await this.context.UserRoles.AsNoTracking().Where(item => item.id == id).FirstOrDefaultAsync();
        }

        //


        public async Task<IEnumerable<DataSelectDTO>> GetAllSelect()
        {
            try
            {
                var sql = @"
                    SELECT Id, CONCAT(Name, ' - ', Description) AS TextoMostrar
                    FROM UserRole
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";

                return await this.context.QueryAsync<DataSelectDTO>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de selección de UserRoles", ex);
            }
        }



        public async Task<IEnumerable<UserRole>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM UserRole ORDER BY Id ASC";
                return await this.context.QueryAsync<UserRole>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los UserRoles", ex);
            }
        }

    }
}