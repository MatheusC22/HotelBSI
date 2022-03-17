using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Cliente
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Cpf {get; set;}
        public string Rg {get; set;}
        public string Endereco {get; set;}
        public string Telefone {get; set;}
        public string Email {get; set;}
        
        [DataType(DataType.Date)]
        public DateTime DtNascimento  {get; set;}
    }
}