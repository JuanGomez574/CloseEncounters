using CloseEncounters.Models;
using CloseEncounters.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloseEncounters.WebAPI.Controllers
{
    public class EncounterController : ApiController
    {
        /// <summary>
        /// Returns all encounters that the current User has created.
        /// </summary>
        /// <returns>Encounter Object(s)</returns>
        public IHttpActionResult Get()
        {
            var eService = CreateEncounterService();
            var encounters = eService.GetEncounters();
            return Ok(encounters);
        }
        /// <summary>
        /// Returns all encounters that the specific Author Id has created.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Encounter Object(s)</returns>
        public IHttpActionResult Get(Guid authorId)
        {
            EncounterService encounterService = CreateEncounterService();
            var encounter = encounterService.GetEncounterByAuthorId(authorId);
            return Ok(encounter);
        }
        /// <summary>
        /// Returns the encounter with the specific Encounter Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Encounter Object</returns>
        public IHttpActionResult Get(int id)
        {
            EncounterService encounterService = CreateEncounterService();
            var encounter = encounterService.GetEncounterByEncounterId(id);
            return Ok(encounter);
        }
        /// <summary>
        /// Creates a encounter object and saves it to the database.
        /// </summary>
        /// <param name="encounter"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Post(EncounterCreate encounter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEncounterService();

            if (!service.CreateEncounter(encounter))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Updates a encounter object and saves it to the database.
        /// </summary>
        /// <param name="encounter"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Put(EncounterEdit encounter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEncounterService();

            if (!service.UpdateEncounter(encounter))
                return InternalServerError();

            return Ok();


        }
        /// <summary>
        /// Selects a certain encounter object with the inputted Encounter Id and removes it from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEncounterService();

            if (!service.DeleteEncounter(id))
                return InternalServerError();

            return Ok();
        }

        private EncounterService CreateEncounterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var encounterService = new EncounterService(userId);
            return encounterService;
        }
    }
}
