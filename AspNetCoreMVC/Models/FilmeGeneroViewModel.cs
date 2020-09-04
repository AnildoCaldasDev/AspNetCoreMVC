
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetCoreMVC.Models
{
    public class FilmeGeneroViewModel
    {
        public List<Filme> filmes;
        public SelectList generos;
        public string filmeGenero { get; set; }
    }
}
