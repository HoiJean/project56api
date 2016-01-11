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
    public class ConnectionsController : ApiController
    {
        private Citygis db = new Citygis();

        // GET: api/Connections
        public IQueryable<connections> Getconnections()
        {
            return db.connections;
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult GetCount(string count)
        {
            var c = (
               db.connections.Count()
             );

            return Ok(c);
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult GetConnectionsPagination(string ConnectionsPagination, int page)
        {

            
            var paginationResults =  db.connections.OrderBy(m => m.Id).Skip((page - 1) * 30).Take(30);

            return Ok(paginationResults);
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult GetFromunit(string fromUnit)
        {
            var newUnitId = Convert.ToDouble(fromUnit);

            var c = (
               db.connections.Where(m => m.Unit_id == newUnitId)
             );

            return Ok(c);
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult Getaa(string aa)
        {

            return Ok(db.connections);
        }

        // GET: api/Connections/5
        [ResponseType(typeof(connections))]
        public IHttpActionResult Getconnections(int id)
        {
            connections connections = db.connections.Find(id);
            if (connections == null)
            {
                return NotFound();
            }

            return Ok(connections);
        }
        
        [ResponseType(typeof(connections))]
        public IHttpActionResult GetconnectionsByDate(DateTime datetime)
        {
            var newdate = datetime.Date;
            string onlydate = newdate.ToString().Split(' ')[0];
            

            string enddate = onlydate + " 23:59:59";
            DateTime dt = Convert.ToDateTime(enddate);

            var result = (
                from c in db.connections
                where c.Datetime>= newdate && c.Datetime <= dt
                select c   
            );

            return Ok(result);
        }

        // PUT: api/Connections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putconnections(int id, connections connections)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != connections.Id)
            {
                return BadRequest();
            }

            db.Entry(connections).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!connectionsExists(id))
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

        // POST: api/Connections
        [ResponseType(typeof(connections))]
        public IHttpActionResult Postconnections(connections connections)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.connections.Add(connections);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = connections.Id }, connections);
        }

        // DELETE: api/Connections/5
        [ResponseType(typeof(connections))]
        public IHttpActionResult Deleteconnections(int id)
        {
            connections connections = db.connections.Find(id);
            if (connections == null)
            {
                return NotFound();
            }

            db.connections.Remove(connections);
            db.SaveChanges();

            return Ok(connections);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool connectionsExists(int id)
        {
            return db.connections.Count(e => e.Id == id) > 0;
        }
    }
}