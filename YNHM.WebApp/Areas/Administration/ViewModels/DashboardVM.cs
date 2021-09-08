using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Areas.Administration.ViewModels
{
    public class DashboardVM
    {
        public ICollection<Roomie> Roomies { get; set; }
        public ICollection<House> Houses { get; set; }
        public ICollection<RoomiesPair> RoomiesPairs { get; set; }

    }
}
