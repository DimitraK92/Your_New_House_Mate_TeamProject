using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Models
{
    public class PersonalProfileVM
    {
        public Roomie CurrentRoomie { get; set; }
        public Roomie ViewedRoomie { get; set; }
        public PersonalProfileVM(Roomie current, Roomie viewed)
        {
            CurrentRoomie = current;
            ViewedRoomie = viewed;
        }

    }
}