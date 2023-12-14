﻿using BLL.Services;
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
        [Route("api/person/{id}")]
        public HttpResponseMessage GetName(int id)
        {
            try
            {
                var data = PersonService.GetName(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
    }
}
