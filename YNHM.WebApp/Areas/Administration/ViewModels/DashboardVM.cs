using System.Collections.Generic;
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
