using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Database.Mockup
{
    [NotMapped]
    public class House
    {
        public int HouseId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Bedrooms { get; set; }
        public int Rent { get; set; }
        public List<string> PhotoUrls { get; set; }
        public string District { get; set; }
        public string MapLocation { get; set; }
        public Person Manager { get; set; }

        public House(int id, string title, string address, string postalCode, int area, int floor, int bedrooms, int rent, List<string> photoUrls, string district, string mapLocation, Person manager)
        {
            HouseId = id;
            Title = title;
            Address = address;
            PostalCode = postalCode;
            Area = area;
            Floor = floor;
            Bedrooms = bedrooms;
            Rent = rent;
            PhotoUrls = photoUrls;
            District = district;
            MapLocation = mapLocation;
            Manager = manager;
        }

        

    }
}
