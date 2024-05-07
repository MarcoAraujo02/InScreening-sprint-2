using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.Models
{
    public class Funcionario
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string status { get; set; }
    }
}
