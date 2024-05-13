using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.DTOs
{
    public class LoginPacienteDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
