using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.DTOs
{
    public class LoginFuncionarioDTO
    {

        [Required]

        public string Nome { get; set; }

        [Required]

        public string Cpf { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
