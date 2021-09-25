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
        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var Locations = locationService.GetLocations();
            return Ok(Locations);
        }

        public IHttpActionResult Get(Guid authorId)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationByAuthorId(authorId);
            return Ok(location);
        }

        public IHttpActionResult Get(int id)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationByLocationId(id);
            return Ok(location);
        }

        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();


        }

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

    

