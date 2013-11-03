using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.MainModule.Entities;

namespace DistributedServices.Web.Mappings
{
    public static class Mapper
    {
        public static Entities.Dto.Bundle Map(Bundle bundle)
        {
            var products = bundle.Products.Select(p => Mapper.Map(p)).ToList();

            var bundleDto = new Entities.Dto.Bundle()
            {
                Description = bundle.Description,
                Name = bundle.Name,
                Id = bundle.Id,
                Products = products
            };

            return bundleDto;
        }

        public static Entities.Dto.Client Map(Client client)
        {
            var clientDto = new Entities.Dto.Client()
            {
                Description = client.Description,
                Email = client.Email,
                Id = client.Id,
                Name = client.Name
            };

            return clientDto;
        }

        public static DistributedServices.Entities.Dto.ClientProduct Map(Domain.MainModule.Entities.ClientProduct clientProduct)
        {
            var clientProductDto = new Entities.Dto.ClientProduct()
            {
                ProductId = clientProduct.ProductId,
                ClientId = clientProduct.ClientId,
                Id = clientProduct.Id
            };

            return clientProductDto;
        }

        public static DistributedServices.Entities.Dto.Customer Map(Domain.MainModule.Entities.Customer customer)
        {
            var customerDto = new Entities.Dto.Customer()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Id = customer.Id
            };

            return customerDto;
        }

        public static DistributedServices.Entities.Dto.Product Map(Domain.MainModule.Entities.Product product)
        {
            var productDto = new Entities.Dto.Product()
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id
            };

            return productDto;
        }
    }
}