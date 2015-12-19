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
    public class PositionsController : ApiController
    {
        private Citygis db = new Citygis();

        // GET: api/Positions
        public IQueryable<positions> Getpositions()
        {
            return db.positions;
        }

        // GET: api/Positions/5
        [ResponseType(typeof(positions))]
        public IHttpActionResult Getpositions(int id)
        {
            positions positions = db.positions.Find(id);
            if (positions == null)
            {
                return NotFound();
            }

            return Ok(positions);
        }

        // PUT: api/Positions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpositions(int id, positions positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != positions.id)
            {
                return BadRequest();
            }

            db.Entry(positions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!positionsExists(id))
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

        // POST: api/Positions
        [ResponseType(typeof(positions))]
        public IHttpActionResult Postpositions(positions positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.positions.Add(positions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = positions.id }, positions);
        }

        // DELETE: api/Positions/5
        [ResponseType(typeof(positions))]
        public IHttpActionResult Deletepositions(int id)
        {
            positions positions = db.positions.Find(id);
            if (positions == null)
            {
                return NotFound();
            }

            db.positions.Remove(positions);
            db.SaveChanges();

            return Ok(positions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool positionsExists(int id)
        {
            return db.positions.Count(e => e.id == id) > 0;
        }
    }
}