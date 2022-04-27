using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HotelApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new HotelAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HotelAppContext>>()))
            {
                // Verificar se há registros
                if(context.Cliente.Any())
                {
                   
                }else{
                    context.Cliente.AddRange(
                    new Cliente
                    {
                        Nome = "Davi Luan Santos",
                        Cpf = "731.976.578-02",
                        Rg = "16.167.051-9",
                        Endereco = "Rua XV de Novembro, 909",
                        Telefone = "(17) 98305-6859",
                        Email = "davi_luan_santos@live.se",
                        DtNascimento = DateTime.Parse("1953-01-22"),
                    },
                    new Cliente
                    {
                        Nome = "Anderson Julio Lima",
                        Cpf = "213.960.478-40",
                        Rg = "1.532.0152-6",
                        Endereco = "Rua Pioneira Vitalina Josefa da Conceição, 801",
                        Telefone = "(18) 99655-9639",
                        Email = "anderson_julio_lima@ideiaviva.com.br",
                        DtNascimento = DateTime.Parse("2000-01-21"),
                    },
                    new Cliente
                    {
                        Nome = "Julio Fernando Osvaldo Cavalcanti",
                        Cpf = "288.328.068-19",
                        Rg = "22.771.820-3",
                        Endereco = "Rua Ítalo Trevisan, 875",
                        Telefone = "(19) 98300-4073",
                        Email = "juliofernandocavalcanti@progetamos.com.br",
                        DtNascimento = DateTime.Parse("1983-01-01"),
                    },
                    new Cliente
                    {
                        Nome = "Benedito Benedito Silva",
                        Cpf = "100.129.938-83",
                        Rg = "50.593.323-8",
                        Endereco = "Rua Votorantim, 675",
                        Telefone = "(19) 99215-2374",
                        Email = "benedito_silva@ceviu.com.br",
                        DtNascimento = DateTime.Parse("1947-03-15"),
                    }
                );
                }
                if(context.Quarto.Any()){
                    // Não faço nada
                }else{
                    context.Quarto.AddRange(
                        new Quarto
                        {
                            Numero = 11,
                            Descricao = "Quarto Standard Casal",
                            TipoQuartoID = 1,
                            Localizacao = "Primeiro Andar",
                            StatusQuarto = "Livre",
                        },
                        new Quarto
                        {
                            Numero = 21,
                            Descricao = "Quarto Deluxe",
                            TipoQuartoID = 2,
                            Localizacao = "Cobertura",
                            StatusQuarto = "Livre",
                        }

                    );
                }

                
                context.SaveChanges();
            }
        }
    }
}