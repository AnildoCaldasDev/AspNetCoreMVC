using AspNetCoreMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AspNetCoreMVC.Models
{
    public class SeedDataFilmes
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FilmesContext(serviceProvider.GetRequiredService<DbContextOptions<FilmesContext>>()))
            {
                if (context.Filmes.Any())
                    return;

                context.Filmes.AddRange(
                     new Filme
                     {
                         Titulo = "A Bela e a Fera",
                         Lancamento = DateTime.Parse("2017-3-16"),
                         Genero = "Fantasia/Romance",
                         Preco = 7.99M
                     },
                     new Filme
                     {
                         Titulo = "Caça-Fantasmas",
                         Lancamento = DateTime.Parse("1984-3-13"),
                         Genero = "Comedia",
                         Preco = 8.99M
                     },
                     new Filme
                     {
                         Titulo = "Kong - A ilha da Caveira",
                         Lancamento = DateTime.Parse("2017-3-09"),
                         Genero = "Ficção",
                         Preco = 9.99M
                     },
                   new Filme
                   {
                       Titulo = "Rio Bravo",
                       Lancamento = DateTime.Parse("1959-4-15"),
                       Genero = "Western",
                       Preco = 3.99M
                   }
                );

                context.SaveChanges();
            }
        }
    }
}
