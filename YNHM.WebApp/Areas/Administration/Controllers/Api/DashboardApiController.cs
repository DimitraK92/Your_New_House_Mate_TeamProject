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
using YNHM.Database;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Controllers.Api
{
    public class DashboardApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/roomies/count")]
        public IHttpActionResult GetRoomiesNumber()
        {
            return Ok(db.Roomies.Count());
        }

        [Route("api/houses/count")]
        public IHttpActionResult GetHousesNumber()
        {
            return Ok(db.Houses.Count());
        }

        [Route("api/pairs/count")]
        public IHttpActionResult GetPairsNumber()
        {
            return Ok(db.RoomiesPair.Count());
        }

        [Route("api/matched/count")]
        public IHttpActionResult GetMatchedUsersNumber()
        {
            return Ok(db.RoomiesPair.Count() * 2);
        }

        [Route("api/unmatched/count")]
        public IHttpActionResult GetUnMatchedUsersNumber()
        {
            return Ok((db.Roomies.Count()) - (db.RoomiesPair.Count() * 2));
        }

        [Route("api/withHouse/count")]
        public IHttpActionResult GetUsersWithHouseNumber()
        {
            return Ok(db.Roomies.Where(r => r.HouseId != null).Count());
        }














        // GET: api/Roomies/5
        [ResponseType(typeof(Roomie))]
        public IHttpActionResult GetRoomie(int id)
        {
            Roomie roomie = db.Roomies.Find(id);
            if (roomie == null)
            {
                return NotFound();
            }

            return Ok(roomie);
        }

        // PUT: api/Roomies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoomie(int id, Roomie roomie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomie.Id)
            {
                return BadRequest();
            }

            db.Entry(roomie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomieExists(id))
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

        // POST: api/Roomies
        [ResponseType(typeof(Roomie))]
        public IHttpActionResult PostRoomie(Roomie roomie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roomies.Add(roomie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roomie.Id }, roomie);
        }

        // DELETE: api/Roomies/5
        [ResponseType(typeof(Roomie))]
        public IHttpActionResult DeleteRoomie(int id)
        {
            Roomie roomie = db.Roomies.Find(id);
            if (roomie == null)
            {
                return NotFound();
            }

            db.Roomies.Remove(roomie);
            db.SaveChanges();

            return Ok(roomie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomieExists(int id)
        {
            return db.Roomies.Count(e => e.Id == id) > 0;
        }
    }
}