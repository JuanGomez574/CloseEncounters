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
                    LocationName = model.LocationName

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
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    AuthorId = e.AuthorId,
                                    NumberOfEncounters= e.NumberOfEncounters,
                                    LocationId = e.LocationId,
                                    LocationName = e.LocationName
                                }
                                );

                return query.ToArray();

            }
        }

        public IEnumerable<LocationDetail> GetLocationByAuthorId(Guid authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.AuthorId == authorId)
                        .Select(
                            e =>
                                new LocationDetail
                                {
                                    AuthorId = e.AuthorId,
                                    NumberOfEncounters = e.NumberOfEncounters,
                                    LocationId = e.LocationId,
                                    LocationName = e.LocationName
                                }
                                );

                return query.ToArray();
            }
        }

        public IEnumerable<LocationListItem> GetLocationByLocationId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.LocationId == id)
                        .Select(
                            e =>

                     new LocationListItem
                     {
                         AuthorId = e.AuthorId,
                         LocationId = e.LocationId,
                         LocationName=e.LocationName,
                         NumberOfEncounters=e.NumberOfEncounters,
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

                
                entity.NumberOfEncounters = model.NumberOfEncounters;
                entity.LocationId = model.LocationId;
                entity.LocationName = model.LocationName;

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


        

