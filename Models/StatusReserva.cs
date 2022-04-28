using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HotelApp.Models
{
    public class StatusReserva
    {
        public int StatusReservaID {get; set;}
        public string Nome  {get; set;}
        [Display(Name="Descrição")]
        public string Descricao  {get; set;}

        public virtual ICollection<Reserva> Reservas {get; set;}
    }
}

