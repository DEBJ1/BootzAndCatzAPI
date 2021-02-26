using BootzAndCatz.Data;
using BootzAndCatz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Services
{
    
    public class CatServices
    {
        private readonly Guid _userId;

        public CatServices(Guid userId)
        {
            _userId = userId;
        }

        //create cat
        public bool CreateCat(CatCreate model)
        {
            var entity =
                new Cat()
                {
                    ShelterId = model.ShelterId,
                    IsDeclawed = model.IsDeclawed,
                    IsFat = model.IsFat,
                    Name = model.Name,
                    Breed = model.Breed,
                    Age = model.Age,
                    AboutMe = model.AboutMe
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cats.Add(entity);
                    return ctx.SaveChanges() == 1;
            }
        }

        //get all cats
        public IEnumerable<CatListItem> GetAllCats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cats
                    .Where(e => e.Shelter.ShelterOwnerId == _userId)
                    .Select(
                        e =>
                        new CatListItem
                        {
                            CatId = e.CatId,
                            Name = e.Name
                        }
                        );
                return query.ToArray();
            }
        }

        //update cat
        public bool UpdateCat(CatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cats
                    .Single(e => e.CatId == model.CatId && e.Shelter.ShelterOwnerId == _userId);
                entity.IsDeclawed = model.IsDeclawed;
                entity.IsFat = model.IsFat;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.AboutMe = model.AboutMe;
                entity.Breed = model.Breed;


                return ctx.SaveChanges() == 1;
            }
        }

        //delete cat
        public bool DeleteCat(int catId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cats
                    .Single(e => e.CatId == catId && e.Shelter.ShelterOwnerId == _userId);

                ctx.Cats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
