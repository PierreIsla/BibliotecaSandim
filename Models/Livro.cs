using System.ComponentModel.DataAnnotations;

namespace BibliotecaISLA.Models
{
    public class Livro
    {
        public int LivroID { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        
        [StringLength(13)]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }
        
        [Display(Name = "Ano de Publicação")]
        public int? AnoPublicacao { get; set; }
        
        public int AutorID { get; set; }
        
        public Autor Autor { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}