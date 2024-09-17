using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public abstract class BaseBusiness<TEntity, TEntityDto> : IBusiness<TEntityDto> where TEntity : class

    {
        protected readonly IMapper _mapper;
        protected readonly IData<TEntity> _data; // Interfaz genérica para acceso a datos

        protected BaseBusiness(IMapper mapper, IData<TEntity> data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<TEntityDto> GetById(int id)
        {
            var entity = await _data.GetById(id);
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var entities = await _data.GetAll();
            return _mapper.Map<IEnumerable<TEntityDto>>(entities);
        }

        public async Task<TEntityDto> Save(TEntityDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _data.Save(entity);
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task Update(int id, TEntityDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _data.Update(id, entity);
        }

        public async Task Delete(int id)
        {
            await _data.Delete(id);
        }
    }
}
