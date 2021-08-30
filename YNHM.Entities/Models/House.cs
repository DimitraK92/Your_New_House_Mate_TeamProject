using System.Collections.Generic;

namespace YNHM.Entities.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int PageViews { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Bedrooms { get; set; }
        public int Rent { get; set; }
        public string District { get; set; }
        public string MapLocation { get; set; }

        public bool ElevatorInBuilding { get; set; }
        public bool FreeWiFi { get; set; }
        public bool Parking { get; set; }
        public bool AirCondition { get; set; }
        public bool PetFriendly { get; set; }
        public bool OutdoorSeating { get; set; }
        public bool WheelchairFriendly { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public int ManagerId { get; set; }
        public virtual HouseManager Manager { get; set; }
    }
}
