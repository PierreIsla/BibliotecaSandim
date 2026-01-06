using System.ComponentModel.DataAnnotations;

namespace BibliotecaISLA.Models
{
    public class Autor
    {
        public int AutorID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        
        [StringLength(50)]
        public string Nacionalidade { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        
        public ICollection<Livro> Livros { get; set; }
    }
}