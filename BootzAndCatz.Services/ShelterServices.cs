using BootzAndCatz.Data;
using BootzAndCatz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Services
{
    public class ShelterServices
    {
        private readonly int _shelterId;

        public ShelterServices(int shelterId)
        {
            _shelterId = shelterId;
        }

        //Shelter Create
        public bool CreateShelter(ShelterCreate model)
        {
            var entity =
                new Shelter()
                {
                    ShelterId = _shelterId,
                    ShelterName = model.ShelterName,
                    ZipCode = model.ZipCode,
                    Description = model.Description,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shelters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all the shelters
        public IEnumerable<ShelterListItem> GetAllSheltes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shelters
                    .Where(e => e.ShelterId == _shelterId)
                    .Select(
                        e =>
                        new ShelterListItem
                        {
                            ShelterId = e.ShelterId,
                            ShelterName = e.ShelterName
                        }
                        );
                return query.ToArray();
            }
        }

        //update shelter
        public bool UpdateShelter(ShelterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shelters
                    .Single(e => e.ShelterId == model.ShelterId);
                entity.ShelterName = model.ShelterName;
                entity.ZipCode = model.ZipCode;
                entity.Description = model.Description;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;


                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Shelter
        public bool DeleteShelter(int shelterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shelters
                    .Single(e => e.ShelterId == shelterId);

                ctx.Shelters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

