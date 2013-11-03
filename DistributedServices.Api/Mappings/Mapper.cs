using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedServices.Api.Mappings
{
    public static class Mapper
    {
        public static DistributedServices.Entities.Dto.Client Map(Infrastructure.Data.MainModule.Models.Client item)
        {
            if (item == null)
                return new Entities.Dto.Client();
            
            var dto = new Entities.Dto.Client()
            {
                Name = item.Name,
                Description = "TEST DESCRIPTION",
                Token = item.Token,
                Id = item.Id
            };

            return dto;
        }
    }
}