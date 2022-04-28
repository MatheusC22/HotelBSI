using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HotelApp.Models
{
    public class StatusQuarto
    {
        public int StatusQuartoID {get; set;}
        public string Nome  {get; set;}
        [Display(Name="Descrição")]
        public string Descricao  {get; set;}

        public virtual ICollection<Quarto> Quartos {get; set;}
    }
}

