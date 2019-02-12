using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Class : BaseModel
    {
        public string Name { get; set; }
        public virtual Department departments { get; set; }
        public virtual Batch batchs { get; set; }
        public virtual Employee employees { get; set; }
    }
}
