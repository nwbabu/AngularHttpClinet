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
using LoginService.Models;
using System.Web.Http.Cors;

namespace LoginService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserRegistationsController : ApiController
    {
        private LoginContext db = new LoginContext();

        // GET: api/UserRegistations
        public IQueryable<UserRegistation> GetRegister()
        {
            return db.Register;
        }

        // GET: api/UserRegistations/5
        [ResponseType(typeof(UserRegistation))]
        public IHttpActionResult GetUserRegistation(int id)
        {
            UserRegistation userRegistation = db.Register.Find(id);
            if (userRegistation == null)
            {
                return NotFound();
            }

            return Ok(userRegistation);
        }

        // PUT: api/UserRegistations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserRegistation(int id, UserRegistation userRegistation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRegistation.id)
            {
                return BadRequest();
            }

            db.Entry(userRegistation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistationExists(id))
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

        // POST: api/UserRegistations
        [ResponseType(typeof(UserRegistation))]
        public IHttpActionResult PostUserRegistation(UserRegistation userRegistation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Register.Add(userRegistation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userRegistation.id }, userRegistation);
        }

        // DELETE: api/UserRegistations/5
        [ResponseType(typeof(UserRegistation))]
        public IHttpActionResult DeleteUserRegistation(int id)
        {
            UserRegistation userRegistation = db.Register.Find(id);
            if (userRegistation == null)
            {
                return NotFound();
            }

            db.Register.Remove(userRegistation);
            db.SaveChanges();

            return Ok(userRegistation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRegistationExists(int id)
        {
            return db.Register.Count(e => e.id == id) > 0;
        }
    }
}