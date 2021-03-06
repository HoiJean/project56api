﻿using System;
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
    public class EventsController : ApiController
    {
        private Citygis db = new Citygis();

        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events.GroupBy(x => x.unit_id).Select(y => y.FirstOrDefault());
        }

        [ResponseType(typeof(Event))]
        public IHttpActionResult GetCount(string count)
        {
            var c = (
               db.Events.Count()
             );

            return Ok(c);
        }

        [ResponseType(typeof(connections))]
        public IHttpActionResult GetEventsPagination(string ConnectionsPagination, int page)
        {


            var paginationResults = db.Events.OrderBy(m => m.Id).Skip((page - 1) * 10).Take(10);

            return Ok(paginationResults);
        }

        [ResponseType(typeof(Event))]
        public IHttpActionResult GetFromunit(string fromUnit)
        {
            var newUnitId = Convert.ToDouble(fromUnit);

            var c = (
               db.Events.Where(m => m.unit_id == newUnitId)
             );

            return Ok(c);
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}