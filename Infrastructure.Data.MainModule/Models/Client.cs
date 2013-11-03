using System;
using System.Collections.Generic;

namespace Infrastructure.Data.MainModule.Models
{
    public partial class Client
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public System.Guid Token { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    }
}
