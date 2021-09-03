using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Models
{
    public class PercentageVM
    {
        public List<Roomie> Roomies { get; set; }

        public Roomie CurrentUser { get; set; }


    }
}