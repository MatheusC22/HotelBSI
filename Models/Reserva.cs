using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Models
{
    public class Reserva
    {
        public int Id {get; set;}
        public int ClienteID {get; set;}
        public int QuartoID {get; set;}
        [DataType(DataType.Date)]
        public DateTime DataCheckIn {get; set;}
        [DataType(DataType.Date)]
        public DateTime DataCheckOut {get; set;}
        public int StatusReservaID {get; set;}

        //Relacionamentos
        public virtual Cliente Cliente {get; set;}
        public virtual Quarto Quarto {get; set;}
        public virtual StatusReserva StatusReserva {get; set;}


    }
}