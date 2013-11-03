using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infrastructure.CrossCutting.IoC;
using DistributedServices.Entities;
using DistributedServices.Api.Mappings;
using Infrastructure.Data.MainModule.Repositories;
using Infrastructure.Data.MainModule.Models;

namespace DistributedServices.Api.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientRepository _repository;
        // Test
        public ClientsController()
        {
            _repository = IoCFactory.Resolve<IClientRepository>();
        }

        /// <summary>
        /// All of the items.
        /// </summary>
        /// <returns>All items.</returns>
        public HttpResponseMessage GetAll()
        {
            var items = _repository.List();

            var itemDto = items.Select(i => Mapper.Map(i));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// A item.
        /// </summary>
        /// <param name="id">Unique identifier for an item.</param>
        /// <returns>Employee title.</returns>
        public HttpResponseMessage Get([FromUri]string token)
        {
            var item = _repository.Get(Guid.Parse(token));

            var itemDto = Mapper.Map(item);

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="item">New item to create in the given bundle.</param>
        /// <returns>The recently created item.</returns>
        public HttpResponseMessage Post([FromBody]Client item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Client());

            var itemDto = Mapper.Map(_repository.Add(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Updates an existing item.
        /// </summary>
        /// <param name="id">Unique identifier for the item to update.</param>
        /// <param name="item">Item to update.</param>
        /// <returns>The recently updated item.</returns>
        public HttpResponseMessage Put([FromUri]string token, [FromBody]Client item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Client());

            item.Token = Guid.Parse(token);

            var itemDto = Mapper.Map(_repository.Update(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Deletes an existing item.
        /// </summary>
        /// <param name="id">Unique identifier for an item.</param>
        /// <returns>The recently deleted item.</returns>
        public HttpResponseMessage Delete([FromUri]string token)
        {
            var itemDto = Mapper.Map(_repository.Delete(Guid.Parse(token)));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }
    }
}
