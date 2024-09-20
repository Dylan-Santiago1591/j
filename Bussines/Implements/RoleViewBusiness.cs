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
    public class RoleViewBusiness : IRoleViewBusiness
    {
        protected readonly IRoleViewData data;

        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleView> roleViews = await this.data.GetAll();
            var roleViewDtos = roleViews.Select(roleView => new RoleViewDto
            {
                id = roleView.id,
            });

            return roleViewDtos;
        }


        public async Task<RoleViewDto> GetById(int id)
        {
            RoleView roleView = await this.data.GetById(id);
            RoleViewDto roleViewDto = new RoleViewDto();

            roleViewDto.id = roleView.id;

            return roleViewDto;
        }

        public RoleView mapearDatos(RoleView roleView, RoleViewDto entity)
        {
            roleView.id = entity.id;

            return roleView;
        }

        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleView = new RoleView();
            roleView.CreatedAt = DateTime.Now.AddHours(-5);
            roleView = this.mapearDatos(roleView, entity);

            return await this.data.Save(roleView);
        }

        public async Task Update(RoleViewDto entity)
        {
            RoleView roleView = await this.data.GetById(entity.id);
            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");
            }

            roleView = this.mapearDatos(roleView, entity);
            await this.data.Update(roleView);
        }
    }
}