using CloseEncounters.Data;
using CloseEncounters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Services
{
    public class CreatureService
    {
        private readonly Guid _userId;

        public CreatureService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCreature(CreatureCreate model)
        {
            var entity =
                new Creature()
                {
                    AuthorId = _userId,
                    DescriptionOfCreature = model.DescriptionOfCreature,
                    CreatureType = model.CreatureType,
                    Height = model.Height,
                    Weight = model.Weight,
                    MythicalOrFolktale = model.MythicalOrFolktale,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Creatures.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CreatureListItem> GetCreatures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Creatures
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new CreatureListItem
                                {
                                    CreatureId = e.CreatureId,
                                    DescriptionOfCreature = e.DescriptionOfCreature,
                                    CreatureType = e.CreatureType,
                                    Height = e.Height,
                                    Weight = e.Weight,
                                    MythicalOrFolktale = e.MythicalOrFolktale,
                                    Name = e.Name
                                }
                                );

                return query.ToArray();

            }
        }

        public CreatureDetail GetCreatureByAuthorId(Guid authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Creatures
                        .FirstOrDefault(e => e.AuthorId == authorId);
                return
                    new CreatureDetail
                    {
                        AuthorId = entity.AuthorId,
                        CreatureId = entity.CreatureId,
                        CreatureType = entity.CreatureType,
                        DescriptionOfCreature = entity.DescriptionOfCreature,
                        Height = entity.Height,
                        MythicalOrFolktale = entity.MythicalOrFolktale,
                        Name = entity.Name,
                        Weight = entity.Weight
                    };
            }
        }

        public bool UpdateCreature(CreatureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Creatures
                        .Single(e => e.CreatureId == model.CreatureId && e.AuthorId == _userId);

                entity.CreatureId = model.CreatureId;
                entity.DescriptionOfCreature = model.DescriptionOfCreature;
                entity.CreatureType = model.CreatureType;
                entity.Height = model.Height;
                entity.Weight = model.Weight;
                entity.MythicalOrFolktale = model.MythicalOrFolktale;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteCreature(int creatureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Creatures
                        .Single(e => e.CreatureId == creatureId);

                ctx.Creatures.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
