using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess
{
    class HotelDbCotext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-8HDV9A7\\SQLEXPRESS;Database=HotelDb;Trusted_Connection=True; MultipleActiveResultSets=true");

        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
