using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YNHM.Database.Models.ViewModels
{
    public class PersonCreateViewModel
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<SelectListItem> SelectedHousesIds
        {
            get
            {
                return db.Houses.ToList().Select(x => new SelectListItem()
                {
                    Value = x.HouseId.ToString(),
                    Text = x.Title
                });
            }
        }

        public Person Person { get; set; }
    }
}
