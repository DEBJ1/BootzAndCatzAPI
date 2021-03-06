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
        ApplicationDbContext _context = new ApplicationDbContext();

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
                    //.Where(e => e.Shelter.ShelterOwnerId == _userId) 
                    //commented out line 51 because I was unsure if user needed authentication to only view cats
                    .Select(
                        e =>
                        new CatListItem
                        {
                            CatId = e.CatId,
                            Name = e.Name
                        }
                        );
                return query.ToArray();
                //End point works but Array is empty. query is null
            }
        }

        //get cats by breed
        public IEnumerable<CatListItem> GetCatsByBreed(string breed)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cats
                    .Where(e => e.Breed == breed)
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
        //get cat by id
        public Cat GetCatById(int id)
        {
            //var services = new ShelterServices()

            var cat = _context.Cats
                .FirstOrDefault(i => i.CatId == id && i.Shelter.ShelterOwnerId ==   _userId);

            return cat;
        }

        //delete cat
        public bool DeleteCat(int id)
        {
            Cat cat = GetCatById(id);

            if (cat == null)
                return false;

            _context.Cats.Remove(cat);

            return _context.SaveChanges() == 1;
        }

        //update cat
        public bool UpdateCat(CatEdit model)
        {
            //add ownerId guid here? (shelter should be the only one able to delete/ update cats
            Cat oldCat = GetCatById(model.CatId);

            if (oldCat != null)
            {
                oldCat.IsDeclawed = model.IsDeclawed;
                oldCat.IsFat = model.IsFat;
                oldCat.Name = model.Name;
                oldCat.Breed = model.Breed;
                oldCat.Age = model.Age;
                oldCat.AboutMe = model.AboutMe;

                return _context.SaveChanges() == 1;
            }
            else
                return false;
        }

    }
}
