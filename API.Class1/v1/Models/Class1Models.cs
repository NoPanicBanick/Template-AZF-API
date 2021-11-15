using System;

namespace API.Class1.v1.Models
{
    /* 
     * Opted to be explicit here versus using inheritance.
     * If complexity increases, consider changing this strategy.
     */

    public class Class1Model : BaseModel
    {
        public Guid ID { get; set; }
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class Class1AddModel
    {
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

    }

    public class Class1UpdateModel
    {
        public Guid ID { get; set; }
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string ETag { get; set; }
    }
}
