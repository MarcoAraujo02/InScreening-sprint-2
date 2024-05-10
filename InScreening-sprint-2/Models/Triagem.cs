using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.Models
{
    public class Triagem
    { 

        [Key]
        public int id {  get; set; }

        [Required]
        public DateTime DataInicio { get; set; }


        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public string Sintomas { get; set; }

        [Required]
        public string Prioridade { get; set; }



    
    }
}
