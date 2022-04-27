using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HotelApp.Models
{
    public class TipoQuarto
    {
        public int TipoQuartoID {get; set;}
        public string Nome  {get; set;}
        [Display(Name="Descrição")]
        public string Descricao  {get; set;}
        [Display(Name="Preço")]
        [DataType(DataType.Currency)]
        public double Preco  {get; set;}

        public virtual ICollection<Quarto> Quartos {get; set;}
    }
}

