using System.Collections.Generic;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Models
{
    public class PercentageVM
    {
        public List<Roomie> Roomies { get; set; }
        public Dictionary<Roomie, int> Compared { get; set; }
        public Roomie CurrentUser { get; set; }

    }
}