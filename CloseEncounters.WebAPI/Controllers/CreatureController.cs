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
    public class CreatureController : ApiController
    {
        public IHttpActionResult Get()
        {
            var cService = CreateCreatureService();
            var creatures = cService.GetCreatures();
            return Ok(creatures);
        }

        public IHttpActionResult Get(Guid authorId)
        {
            CreatureService creatureService = CreateCreatureService();
            var creature = creatureService.GetCreatureByAuthorId(authorId);
            return Ok(creature);
        }

        public IHttpActionResult Post(CreatureCreate creature)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCreatureService();

            if (!service.CreateCreature(creature))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CreatureEdit creature)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCreatureService();

            if (!service.UpdateCreature(creature))
                return InternalServerError();

            return Ok();


        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCreatureService();

            if (!service.DeleteCreature(id))
                return InternalServerError();

            return Ok();
        }

        private CreatureService CreateCreatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var creatureService = new CreatureService(userId);
            return creatureService;
        }
    }
}
