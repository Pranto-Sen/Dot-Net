using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAppLayer.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("api/person/all")]
        public HttpResponseMessage all()
        {
            try
            {
                var data = PersonService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        [Route("api/person/create")]
        public HttpResponseMessage create(PersonDTO p)
        {
            try
            {
                var data = PersonService.Add(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
