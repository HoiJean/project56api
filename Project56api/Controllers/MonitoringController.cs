using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Project56api.Models;

namespace Project56api.Controllers
{
    public class MonitoringController : ApiController
    {
        private Citygis db = new Citygis();

        // GET: api/Monitoring
        public IQueryable<Monitor> GetMonitors()
        {
            return db.Monitors.GroupBy(x => x.Unit_id).Select(y => y.FirstOrDefault());
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult GetCount(string count)
        {
            var c = (
               db.Monitors.Count()
             );

            return Ok(c);
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult GetMonitoringPagination(string ConnectionsPagination, int page)
        {


            var paginationResults = db.Monitors.OrderBy(m => m.Id).Skip((page - 1) * 30).Take(30);

            return Ok(paginationResults);
        }

        // GET: api/Monitoring/5
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult GetMonitor(int id)
        {
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return NotFound();
            }

            return Ok(monitor);
        }

        // PUT: api/Monitoring/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitor(int id, Monitor monitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitor.Id)
            {
                return BadRequest();
            }

            db.Entry(monitor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Monitoring
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult PostMonitor(Monitor monitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitors.Add(monitor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitor.Id }, monitor);
        }

        // DELETE: api/Monitoring/5
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult DeleteMonitor(int id)
        {
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return NotFound();
            }

            db.Monitors.Remove(monitor);
            db.SaveChanges();

            return Ok(monitor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitorExists(int id)
        {
            return db.Monitors.Count(e => e.Id == id) > 0;
        }
    }
}