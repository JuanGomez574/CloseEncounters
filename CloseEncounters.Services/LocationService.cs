using CloseEncounters.Data;
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
                    NumberOfEncounters = model.NumberOfEncounters,
                    LocationId = model.LocationId,
                    
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
                                    NumberOfEncounters= e.NumberOfEncounters,
                                    LocationId = e.LocationId,
                                }
                                );

                return query.ToArray();

            }
        }

        public LocationDetail GetLocationByAuthorId(Guid authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.AuthorId == authorId);
                return
                    new LocationDetail
                    {
                        AuthorId = entity.AuthorId,
                        LocationId = entity.LocationId,
                        LocationName = entity.LocationName,
                        NumberOfEncounters = entity.NumberOfEncounters
                    };
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

                
                entity.NumberOfEncounters = model.NumberOfEncounters;
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


        

