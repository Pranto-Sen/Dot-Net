using IntroAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        [HttpGet]
        [Route("api/departments/all")]
        public HttpResponseMessage AllDept()
        {
            var db = new DemoF23_AEntities();
            try
            {
                var data = db.Departments.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/department/{id}")]
        public HttpResponseMessage SingleDept(int id)
        {
            var db = new DemoF23_AEntities();
            try
            {
                var data = db.Departments.Find(id);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Data not found" });
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/department/create")]
        public HttpResponseMessage CreateDept(Department d)
        {
            var db = new DemoF23_AEntities();
            try
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new {msg = "Create"});
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/department/delete/{id}")]
        public HttpResponseMessage DeleteDept(int id)
        {
            var db = new DemoF23_AEntities();
            try
            {
                var exdata = db.Departments.Find(id);
                if(exdata != null)
                {
                    db.Departments.Remove(exdata);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Delete successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "No data found" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/department/update")]
        public HttpResponseMessage UpdateDept(Department d)
        {
            var db = new DemoF23_AEntities();
            try
            {
                var exdata = db.Departments.Find(d.id);
                db.Entry(exdata).CurrentValues.SetValues(d);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Update successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
