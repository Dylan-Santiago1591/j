using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public class ModuleBusiness : IModuleBusiness
    {
        protected readonly IModuleData data;
        public ModuleBusiness(IModuleData data) 
        {
            this.data = data;
        }

        public async Task Delete(int id) 
        { 
            await this.data.Delete(id);
        }


        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            IEnumerable<Module> modules = await this.data.GetAll();
            var moduleDtos = modules.Select(module => new ModuleDto
            {
                id = module.id,
                Description = module.Description,
            });
            return moduleDtos;
        }

        public async Task<ModuleDto> GetById(int id) 
        {
            Module module = await this.data.GetById(id);
            ModuleDto moduleDto = new ModuleDto();
            moduleDto.id = id;
            moduleDto.Description = module.Description;
            return moduleDto;
        }


        public Module mapearDatos(Module module, ModuleDto entity) 
        {
            module.id = entity.id;
            module.Description = entity.Description;
            return module;
        }

        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module.CreatedAt = DateTime.Now.AddHours(-5);
            module = this.mapearDatos(module, entity);
            return await this.data.Save(module);
        }


        public async Task Update(ModuleDto entity)
        {
            Module module = await this.data.GetById(entity.id);
            if (module == null) {
                throw new Exception("REGISTRO NO ENCONTRADO");
            }
            module = this.mapearDatos(module, entity);
            await this.data.Update(module);
        }
    }
}
