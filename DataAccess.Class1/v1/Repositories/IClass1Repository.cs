using DataAccess.Class1.v1.DataEntities;
using System.Threading.Tasks;

namespace DataAccess.Class1.v1.Repositories
{
    public interface IClass1Repository
    {
        Task<Class1TableEntity> AddAsync(Class1TableEntity entity);
        Task<Class1TableEntity> GetByIDAsync(string rowKey);
        Task<Class1TableEntity> UpdateAsync(Class1TableEntity entity);
        Task DeleteAsync(string rowKey);
        Task<Class1TableEntity> GetByExternalIDAsync(string externalID);
    }
}
