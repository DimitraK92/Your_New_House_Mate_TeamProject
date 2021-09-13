using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Models
{
    public class MatchDetailsVM
    {
        public Dictionary<Roomie, int> PairedRoomies { get; set; }
        public House House { get; set; }
    }
}