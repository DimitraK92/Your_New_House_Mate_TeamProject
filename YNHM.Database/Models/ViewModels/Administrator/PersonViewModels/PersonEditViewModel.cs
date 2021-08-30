using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YNHM.Database.Models.ViewModels
{
    public class PersonEditViewModel
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<SelectListItem> SelectedHousesIds
        {
            get
            {
                if (Person is null)
                {
                    return db.Houses.ToList().Select(x => new SelectListItem()
                    {
                        Value = x.HouseId.ToString(),
                        Text = x.Title
                    });
                }
                else
                {
                    //if (Person.OwnsHouses == null) { return SelectedHousesIds.DefaultIfEmpty(); }

                    var housesIds = Person.OwnsHouses.Select(x => x.HouseId);

                    return db.Houses.ToList().Select(x => new SelectListItem()
                    {
                        Value = x.HouseId.ToString(),
                        Text = x.Title,
                        Selected = housesIds.Any(y => y == x.HouseId)
                    });
                }


            }
        }
        public Person Person { get; set; }

        public PersonEditViewModel(Person person)
        {
            Person = person;           
        }
    }
}
