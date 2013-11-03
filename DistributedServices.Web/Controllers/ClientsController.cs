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
using Domain.MainModule.Clients;

namespace DistributedServices.Web.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientService _service;

        public ClientsController()
        {
            _service = IoCFactory.Resolve<IClientService>();
        }

        [GET("api/clients")]
        public HttpResponseMessage GetAll()
        {
            var items = _service.List();

            var itemDto = items.Select(i => Mapper.Map(i));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [GET("api/clients/{id}")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            var item = _service.Get(id);

            var itemDto = Mapper.Map(item);

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [POST("api/clients")]
        public HttpResponseMessage Post([FromBody]Client item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Client());

            var itemDto = Mapper.Map(_service.Add(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [PUT("api/clients/{id}")]
        public HttpResponseMessage Put([FromBody]Client item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Product());

            var itemDto = Mapper.Map(_service.Update(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        [DELETE("api/clients/{id}")]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            var itemDto = Mapper.Map(_service.Delete(id));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }
    }
}
