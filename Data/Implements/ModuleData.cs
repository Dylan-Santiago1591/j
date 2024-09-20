using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class ModuleData : IModuleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) {
                throw new Exception("REGISTRO NO ENCONTRADO");
            }
            context.Modules.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Module> GetById(int id)
        {
            var sql = @"SELECT * FROM Module WHERE id = @id ORDER BY id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Module>(sql, new {Id =id });
        }

        public async Task<Module> Save(Module entity)
        {
            context.Modules.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Module> GetByName(String Description)
        {
            return await this.context.Modules.AsNoTracking().Where(item => item.Description == Description).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DataSelectDTO>> GetAllSelect()
        {
            try
            {
                var sql = @"SELECT id, CONCAT(Name, ' - ', Description) AS TextoMostrar
                           FROM Module WHERE Deleted_at IS NULL AND State = 1 ORDER BY id ASC";
                return await this.context.QueryAsync<DataSelectDTO>(sql);
            }
            catch (Exception ex) 
            {
                throw new Exception("ERROR al obtener la lista de seleccion de Modules", ex);
                
            }
        }

        public async Task<IEnumerable<Module>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM Module ORDER BY id ASC";
                return await this.context.QueryAsync<Module>(sql);
            }
            catch (Exception ex) 
            {
                throw new Exception("ERROR al obtener todos los modules", ex);
            }
        }
    }
}
