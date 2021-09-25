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
        public IHttpActionResult Get()
        {
            var eService = CreateEncounterService();
            var encounters = eService.GetEncounters();
            return Ok(encounters);
        }

        public IHttpActionResult Get(Guid authorId)
        {
            EncounterService encounterService = CreateEncounterService();
            var encounter = encounterService.GetEncounterByAuthorId(authorId);
            return Ok(encounter);
        }

        public IHttpActionResult Get(int id)
        {
            EncounterService encounterService = CreateEncounterService();
            var encounter = encounterService.GetEncounterByEncounterId(id);
            return Ok(encounter);
        }

        public IHttpActionResult Post(EncounterCreate encounter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEncounterService();

            if (!service.CreateEncounter(encounter))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(EncounterEdit encounter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEncounterService();

            if (!service.UpdateEncounter(encounter))
                return InternalServerError();

            return Ok();


        }

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
