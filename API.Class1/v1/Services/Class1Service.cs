using API.Class1.v1.Models;
using AutoMapper;
using DataAccess.Class1.v1.DataEntities;
using DataAccess.Class1.v1.Repositories;
using System;
using System.Threading.Tasks;

namespace API.Class1.v1.Services
{
    public class Class1Service : IClass1Service
    {
        private readonly IMapper _mapper;
        private readonly IClass1Repository _Class1Repository;

        public Class1Service(IMapper mapper, IClass1Repository Class1Repository)
        {
            _mapper = mapper;
            _Class1Repository = Class1Repository;
        }

        public async Task<Class1Model> GetByIDAsync(Guid id)
        {
            var response = await _Class1Repository.GetByIDAsync(id.ToString());
            return _mapper.Map<Class1Model>(response);
        }

        public async Task<Class1Model> GetByExternalIDAsync(string externalId)
        {
            var response = await _Class1Repository.GetByIDAsync(externalId);
            return _mapper.Map<Class1Model>(response);
        }

        public async Task<Class1Model> AddAsync(Class1AddModel model)
        {
            var entity = _mapper.Map<Class1TableEntity>(model);
            var response = await _Class1Repository.AddAsync(entity);
            return _mapper.Map<Class1Model>(response);
        }

        public async Task<Class1Model> UpdateAsync(Class1UpdateModel model)
        {
            var entity = _mapper.Map<Class1TableEntity>(model);
            var response = await _Class1Repository.UpdateAsync(entity);
            return _mapper.Map<Class1Model>(response);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _Class1Repository.DeleteAsync(id.ToString());
        }
    }
}
