using API.Class1.v1.Models;
using System;
using System.Threading.Tasks;

namespace API.Class1.v1.Services
{
    public interface IClass1Service
    {
        Task<Class1Model> GetByIDAsync(Guid id);
        Task<Class1Model> GetByExternalIDAsync(string externalId);
        Task<Class1Model> AddAsync(Class1AddModel model);
        Task<Class1Model> UpdateAsync(Class1UpdateModel model);
        Task DeleteAsync(Guid id);
    }
}
