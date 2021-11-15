using DataAccess.Class1.v1.DataEntities;
using Microsoft.Azure.Cosmos.Table;
using PoorMan;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Class1.v1.Repositories
{
    public class Class1Repository : IClass1Repository
    {
        private const string _defaultPartionKey = "1";
        private readonly ITable<Class1TableEntity> _tableService;

        public Class1Repository(ITable<Class1TableEntity> tableService)
        {
            _tableService = tableService;
        }

        public async Task<Class1TableEntity> AddAsync(Class1TableEntity entity)
        {
            entity.RowKey = Guid.NewGuid().ToString();
            entity.PartitionKey = _defaultPartionKey;
            return await _tableService.AddAsync(entity);
        }

        public async Task<Class1TableEntity> GetByIDAsync(string rowKey)
        {
            return await _tableService.GetAsync(_defaultPartionKey, rowKey);
        }

        public async Task<Class1TableEntity> GetByExternalIDAsync(string externalID)
        {
            var query = TableQuery.GenerateFilterCondition(nameof(Class1TableEntity.ExternalID), QueryComparisons.Equal, externalID);
            return (await _tableService.QueryAsync(query)).FirstOrDefault();
        }

        public async Task<Class1TableEntity> UpdateAsync(Class1TableEntity entity)
        {
            entity.PartitionKey = _defaultPartionKey;
            return await _tableService.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string rowKey)
        {
            await _tableService.DeleteAsync(_defaultPartionKey, rowKey);
        }
    }
}
