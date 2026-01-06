using System.ComponentModel.DataAnnotations;

namespace BibliotecaISLA.Models
{
    public class Membro
    {
        public int MembroID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Inscrição")]
        public DateTime DataInscricao { get; set; }
        
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}