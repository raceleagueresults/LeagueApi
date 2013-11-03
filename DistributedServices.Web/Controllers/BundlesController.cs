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

namespace DistributedServices.Web.Controllers
{
    public class BundlesController : ApiController
    {
        private readonly IBundleService _bundleService;

        public BundlesController()
        {
            _bundleService = IoCFactory.Resolve<IBundleService>();
        }

        [GET("api/bundles/{id}")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            var bundle = _bundleService.GetBundle(id);

            var bundleDto = Mapper.Map(bundle);

            return Request.CreateResponse(HttpStatusCode.OK, bundleDto);
        }

        [POST("api/bundles")]
        public HttpResponseMessage Post([FromBody]Bundle bundle)
        {
            if (bundle == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Bundle());

            var addBundleDto = Mapper.Map(_bundleService.AddBundle(bundle));

            return Request.CreateResponse(HttpStatusCode.OK, addBundleDto);
        }

        [PUT("api/bundles/{id}")]
        public HttpResponseMessage Put([FromUri]int id, [FromBody]Bundle bundle)
        {
            if (bundle == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Bundle());

            var updateBundleResponse = Mapper.Map(_bundleService.UpdateBundle(bundle));

            return Request.CreateResponse(HttpStatusCode.OK, updateBundleResponse);
        }

        [DELETE("api/bundles/{id}")]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            var deleteBundleRequest = new Bundle();

            var deleteBundleDto = Mapper.Map(_bundleService.DeleteBundle(id));

            return Request.CreateResponse(HttpStatusCode.OK, deleteBundleDto);
        }
    }
}
