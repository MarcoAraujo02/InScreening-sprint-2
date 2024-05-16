using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.DTOs
{
    public class CadastroFuncionarioDTO
    {


        public int Id { get; set; }

        [Required]
   
        public string Nome{ get; set; } = string.Empty;

        [Required]

        public string Cpf { get; set; } = string.Empty;

        [Required]

        public string Email { get; set; } = string.Empty;
       
    }
}
