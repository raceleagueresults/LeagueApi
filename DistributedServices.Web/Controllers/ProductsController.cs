using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.MainModule.Bundles;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.IoC;
using DistributedServices.Entities;
using DistributedServices.Web.Mappings;
using AttributeRouting.Web.Http;
using Domain.MainModule.Products;

namespace DistributedServices.Web.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController()
        {
            _service = IoCFactory.Resolve<IProductService>();
        }

        [GET("api/bundles/{bundleId}/products")]
        public HttpResponseMessage GetAll([FromUri]int bundleId)
        {
            var items = _service.List(new Product() { BundleId = bundleId });

            var itemDto = items.Select(i => Mapper.Map(i));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [GET("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Get([FromUri]int bundleId, [FromUri]int id)
        {
            var item = _service.Get(id);

            var itemDto = Mapper.Map(item);

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [POST("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Post([FromUri]int bundleId, [FromBody]Product item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Product());

            item.BundleId = bundleId;

            var itemDto = Mapper.Map(_service.Add(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [PUT("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Put([FromUri]int bundleId, [FromUri]int id, [FromBody]Product item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Product());

            item.BundleId = bundleId;

            var itemDto = Mapper.Map(_service.Update(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [DELETE("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Delete([FromUri]int bundleId, [FromUri]int id)
        {
            var itemDto = Mapper.Map(_service.Delete(id));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }
    }
}
