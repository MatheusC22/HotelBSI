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

        public DbSet<HotelApp.Models.Quarto> Quarto { get; set; }

        public DbSet<HotelApp.Models.TipoQuarto> TipoQuarto { get; set; }

        public DbSet<HotelApp.Models.StatusQuarto> StatusQuarto { get; set; }

        public DbSet<HotelApp.Models.StatusReserva> StatusReserva { get; set; }

        public DbSet<HotelApp.Models.Reserva> Reserva { get; set; }
    }
