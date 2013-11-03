using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedServices.Entities.Dto
{
    public class Client
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public System.Guid Token { get; set; }
    }
}
