using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreMVC.Models
{
    [Table("Filmes")]
    public class Filme
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Data de Lançamento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [DisplayName("Gênero")]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Genero { get; set; }

        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1, 100)]
        public decimal Preco { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Classificacao { get; set; }
    }
}
