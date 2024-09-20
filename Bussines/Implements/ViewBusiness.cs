using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public class ViewBusiness : IViewBusiness
    {
        protected readonly IViewData data;

        public ViewBusiness(IViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            IEnumerable<View> views = await this.data.GetAll();
            var viewDtos = views.Select(view => new ViewDto
            {
                id = view.id,
                Name = view.Name,
                Description = view.Description,
            });

            return viewDtos;
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.data.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.id = view.id;
            viewDto.Name = view.Name;
            viewDto.Description = view.Description;

            return viewDto;
        }

        public View mapearDatos(View view, ViewDto entity)
        {
            view.id = entity.id;
            view.Name = entity.Name;
            view.Description = entity.Description;

            return view;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view.CreatedAt = DateTime.Now.AddHours(-5);
            view = this.mapearDatos(view, entity);
            view.ModuleId = null;

            return await this.data.Save(view);
        }

        public async Task Update(ViewDto entity)
        {
            View view = await this.data.GetById(entity.id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }

            view = this.mapearDatos(view, entity);
            await this.data.Update(view);
        }
    }
}
