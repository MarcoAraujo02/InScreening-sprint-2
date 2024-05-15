using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.DTOs
{
    public class CadastroTriagemDTO
    {

        [Required]
        public DateTime Datainicio { get; set; } 


        [Required]
        public DateTime Datafim { get; set; } 


        [Required]
        public string Sintomas { get; set; }


        [Required]
        public string Prioridade { get; set; } 


    }
}
