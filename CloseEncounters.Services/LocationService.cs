﻿using CloseEncounters.Data;
using CloseEncounters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    AuthorId = _userId,
                    CreatureId = model.CreatureId,
                    NumberOfEncounters = model.NumberOfEncounters,
                    LocationId = model.LocationId,
                    EncounterId = model.EncounterId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    EncounterId = e.EncounterId,
                                    CreatureId = e.CreatureId,
                                    NumberOfEncounters= e.NumberOfEncounters,
                                    LocationId = e.LocationId,
                                }
                                );

                return query.ToArray();

            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == model.LocationId && e.AuthorId == _userId);

                entity.EncounterId = model.EncounterId;
                entity.NumberOfEncounters = model.NumberOfEncounters;
                entity.CreatureId = model.CreatureId;
                entity.LocationId = model.LocationId;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteLocation(int LocationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == LocationId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}


        

