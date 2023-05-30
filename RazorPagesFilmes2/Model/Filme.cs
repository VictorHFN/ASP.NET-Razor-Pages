using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesFilmes2.Model
{
    public class Filme
    {
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [MaxLength(100, ErrorMessage = "errou")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Digite o genero do filme")]
        [StringLength(30, MinimumLength =3)]

        public string Genero { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2")]

        public decimal Preco { get; set; }

        [Range(0,5)]
        public int Pontos { get; set; } = 0;
    }
}
