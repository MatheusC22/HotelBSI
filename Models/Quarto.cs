using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Quarto
    {
        public int Id {get; set;}
        public int Numero  {get; set;}
        public string Descricao  {get; set;}
        public int TipoQuartoID  {get; set;}
        public string Localizacao {get; set;}
        public string StatusQuarto {get; set;}

        public virtual TipoQuarto TipoQuarto {get; set;}
    }
}