using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.Models
{
    public class Triagem
    { 

        [Key]
        public int id {  get; set; }

        [Required]
        public DateTime DataInicio { get; set; } = System.DateTime.Now;

        [Required]
        public DateTime DataFim { get; set; } =  System.DateTime.Now;

        [Required]
        public string Sintomas { get; set; }

        [Required]
        public string Prioridade { get; set; } = "Normal";


        public ICollection<User> usuario { get; set; }

    }
}
