using System.ComponentModel.DataAnnotations;

namespace BibliotecaISLA.Models
{
    public class Emprestimo
    {
        public int EmprestimoID { get; set; }
        
        public int LivroID { get; set; }
        public int MembroID { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Empréstimo")]
        public DateTime DataEmprestimo { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Devolução")]
        public DateTime? DataDevolucao { get; set; }
        
        public Livro Livro { get; set; }
        public Membro Membro { get; set; }
    }
}