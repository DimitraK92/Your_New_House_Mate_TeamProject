using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Models
{
    public class TakeTestVM
    {
        public bool IsSmoking { get; set; }
        public bool IsVegan { get; set; }
        public bool IsNoisy { get; set; }
        public bool LikesCleaning { get; set; }
        public bool IsCatPerson { get; set; }
    }
}