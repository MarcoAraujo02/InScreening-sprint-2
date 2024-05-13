using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string Nome { get; set; }


        [Required]
        public string Cpf { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Senha { get; set; }


        [Required]
        public string Rg { get; set; }


        [Required]
        public string Orgao_emissor { get; set; }


        [Required]
        public string F_paterna { get; set; }


        [Required]
        public string F_materna { get; set; }


        [Required]
        public string Nascimento { get; set; }


        [Required]
        public string Sexo { get; set; }


        [Required]
        public string Cep { get; set; }


        [Required]
        public string Rua { get; set; }


        [Required]
        public string Cidade { get; set; }


        [Required]
        public string Estado { get; set; }


        [Required]
        public string Complemento { get; set; }


        [Required]
        public string Numero { get; set; }

    }
}
