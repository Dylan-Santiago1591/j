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
    public class StateBusiness : IStateBusiness
    {
        protected readonly IStateData data;

        public StateBusiness(IStateData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            IEnumerable<State> states = await this.data.GetAll();
            var stateDtos = states.Select(state => new StateDto
            {
                id = state.id,
                Name = state.Name,
            });

            return stateDtos;
        }

        public async Task<StateDto> GetById(int id)
        {
            State state = await this.data.GetById(id);
            StateDto stateDto = new StateDto
            {
                id = state.id,
                Name = state.Name,
            };

            return stateDto;
        }

        public State mapearDatos(State state, StateDto entity)
        {
            state.id = entity.id;
            state.Name = entity.Name;

            return state;
        }

        public async Task<State> Save(StateDto entity)
        {
            State state = new State
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            state = this.mapearDatos(state, entity);

            return await this.data.Save(state);
        }

        public async Task Update(StateDto entity)
        {
            State state = await this.data.GetById(entity.id);
            if (state == null)
            {
                throw new Exception("Registro no encontrado");
            }

            state = this.mapearDatos(state, entity);
            await this.data.Update(state);
        }
    }
}