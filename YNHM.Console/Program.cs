using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using YNHM.Database;
using YNHM.Entities.Models;
using YNHM.Entities.TestResources;

namespace YNHM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Random rand = new Random();
            

            int count = 1;
            foreach (var h in context.Houses)
            {
                System.Console.WriteLine($"{count} {h.Address}, {h.District}");
                System.Console.WriteLine($"Floor: {h.Floor}, Rooms: {h.Bedrooms}, Rent: {h.Rent}, Area: {h.Area}");
                System.Console.WriteLine();
                count++;
            }

            



        }
    }
}
