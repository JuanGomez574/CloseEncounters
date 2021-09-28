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
        /// <summary>
        /// Returns all creatures that the current User has created.
        /// </summary>
        /// <returns>Creature Object(s)</returns>
        public IHttpActionResult Get()
        {
            var cService = CreateCreatureService();
            var creatures = cService.GetCreatures();
            return Ok(creatures);
        }

        /// <summary>
        /// Returns all creatures that the specific Author Id has created.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Creature Object(s)</returns>
        public IHttpActionResult Get(Guid authorId)
        {
            CreatureService creatureService = CreateCreatureService();
            var creature = creatureService.GetCreatureByAuthorId(authorId);
            return Ok(creature);
        }

        /// <summary>
        /// Returns the creature with the specific Creature Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Creature Object</returns>
        public IHttpActionResult Get(int id)
        {
            CreatureService creatureService = CreateCreatureService();
            var creature = creatureService.GetCreatureByCreatureId(id);
            return Ok(creature);
        }

        /// <summary>
        /// Creates a creature object and saves it to the database.
        /// </summary>
        /// <param name="creature"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Post(CreatureCreate creature)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCreatureService();

            if (!service.CreateCreature(creature))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Updates a creature object and saves it to the database.
        /// </summary>
        /// <param name="creature"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Put(CreatureEdit creature)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCreatureService();

            if (!service.UpdateCreature(creature))
                return InternalServerError();

            return Ok();


        }

        /// <summary>
        /// Selects a certain creature object with the inputted Creature Id and removes it from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IHttpActionResult</returns>
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
