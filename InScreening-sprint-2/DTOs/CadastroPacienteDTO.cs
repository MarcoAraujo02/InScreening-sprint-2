using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.DTOs
{
    public class CadastroPacienteDTO
    {

        [Required]
        public string Name { get; set; } = string.Empty;


        [Required]
        public string Cpf { get; set; } = string.Empty;


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        [Required]
        public string Rg { get; set; } = string.Empty;

        [Required]
        public string Orgao_Emissor { get; set; } = string.Empty;

        
        public string F_Paterna { get; set; } = string.Empty;


        [Required]
        public string F_Materna { get; set; } = string.Empty;


        [Required]
        public string Dt_Nascimento { get; set; } = string.Empty;


        [Required]
        public string Sexo { get; set; } = string.Empty;


        [Required]
        public string Cep { get; set; } = string.Empty;


        [Required]
        public string Rua { get; set; } = string.Empty;


        [Required]
        public string Cidade { get; set; } = string.Empty;


        [Required]
        public string Complemento { get; set; } = string.Empty;


        [Required]
        public string Estado { get; set; } = string.Empty;


        [Required]
        public string Numero{ get; set; } = string.Empty;


    }
}
