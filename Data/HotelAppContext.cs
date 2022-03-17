using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelApp.Models;

    public class HotelAppContext : DbContext
    {
        public HotelAppContext (DbContextOptions<HotelAppContext> options)
            : base(options)
        {
        }

        public DbSet<HotelApp.Models.Cliente> Cliente { get; set; }
    }
