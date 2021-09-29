using CloseEncounters.Data;
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
    public class LocationController : ApiController
    {
        /// <summary>
        /// Returns all locations that all users have created.
        /// </summary>
        /// <returns>Location Object(s)</returns>
        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var Locations = locationService.GetLocations();
            return Ok(Locations);
        }
        /// <summary>
        /// Returns all locations that the specific Author Id has created.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Location Object(s)</returns>
         public IHttpActionResult Get(Guid authorId)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationByAuthorId(authorId);
            return Ok(location);
        }

        /// <summary>
        /// Returns the location with the specific Location Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Location Object</returns>

        public IHttpActionResult Get(int id)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationByLocationId(id);
            return Ok(location);
        }

        /// <summary>
        /// Creates a location object and saves it to the database.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>IHttpActionResult</returns>

        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Updates a location object and saves it to the database.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>IHttpActionResult</returns>

        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();


        }

        /// <summary>
        /// Selects a certain location object with the inputted Location Id and removes it from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IHttpActionResult</returns>

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(id))
                return InternalServerError();

            return Ok();
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }
    }
}

    

