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
using glassfactory.Models;

namespace glassfactory.Controllers
{
    public class TextEntriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TextEntries
        public IQueryable<TextEntry> GetTextEntries()
        {
            return db.TextEntries;
        }

        // GET: api/TextEntries/5
        [ResponseType(typeof(TextEntry))]
        public IHttpActionResult GetTextEntry(int id)
        {
            TextEntry textEntry = db.TextEntries.Find(id);
            if (textEntry == null)
            {
                return NotFound();
            }

            return Ok(textEntry);
        }

        // PUT: api/TextEntries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTextEntry(int id, TextEntry textEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != textEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(textEntry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextEntryExists(id))
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

        // POST: api/TextEntries
        [ResponseType(typeof(TextEntry))]
        public IHttpActionResult PostTextEntry(TextEntry textEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TextEntries.Add(textEntry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = textEntry.Id }, textEntry);
        }

        // DELETE: api/TextEntries/5
        [ResponseType(typeof(TextEntry))]
        public IHttpActionResult DeleteTextEntry(int id)
        {
            TextEntry textEntry = db.TextEntries.Find(id);
            if (textEntry == null)
            {
                return NotFound();
            }

            db.TextEntries.Remove(textEntry);
            db.SaveChanges();

            return Ok(textEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TextEntryExists(int id)
        {
            return db.TextEntries.Count(e => e.Id == id) > 0;
        }
    }
}