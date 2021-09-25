using CloseEncounters.Data;
using CloseEncounters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Services
{
    public class EncounterService
    {
        private readonly Guid _userId;

        public EncounterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEncounter(EncounterCreate model)
        {
            var entity =
                new Encounter()
                {
                    AuthorId = _userId,
                    CreatureId = model.CreatureId,
                    DescriptionOfEncounter = model.DescriptionOfEncounter,
                    LocationId = model.LocationId,
                    DateOfEncounter = model.DateOfEncounter
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Encounters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EncounterListItem> GetEncounters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Encounters
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new EncounterListItem
                                {
                                    AuthorId = e.AuthorId,
                                    EncounterId = e.EncounterId,
                                    CreatureId = e.CreatureId,
                                    DateOfEncounter = e.DateOfEncounter,
                                    DescriptionOfEncounter = e.DescriptionOfEncounter,
                                    LocationId = e.LocationId
                                }
                                );

                return query.ToArray();

            }
        }

        public EncounterDetail GetEncounterByAuthorId(Guid authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Encounters
                        .Single(e => e.AuthorId == authorId);
                return
                    new EncounterDetail
                    {
                        AuthorId = entity.AuthorId,
                        EncounterId = entity.EncounterId,
                        CreatureId = entity.CreatureId,
                        DateOfEncounter = entity.DateOfEncounter,
                        DescriptionOfEncounter = entity.DescriptionOfEncounter,
                        LocationId = entity.LocationId
                    };
            }
        }

        public bool UpdateEncounter(EncounterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Encounters
                        .Single(e => e.EncounterId == model.EncounterId && e.AuthorId == _userId);

                entity.EncounterId = model.EncounterId;
                entity.DescriptionOfEncounter = model.DescriptionOfEncounter;
                entity.CreatureId = model.CreatureId;
                entity.DateOfEncounter = model.DateOfEncounter;
                entity.LocationId = model.LocationId;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteEncounter(int encounterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Encounters
                        .Single(e => e.EncounterId == encounterId);

                ctx.Encounters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

