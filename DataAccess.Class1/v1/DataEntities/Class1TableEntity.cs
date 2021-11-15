using Microsoft.Azure.Cosmos.Table;
using PoorMan;
using System;

namespace DataAccess.Class1.v1.DataEntities
{
    public class Class1TableEntity : TableEntity, IAudit
    {
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime CreatedOnUTCDate { get; set; }
        public DateTime LastModifiedOnUTCDate { get; set; }
    }
}
