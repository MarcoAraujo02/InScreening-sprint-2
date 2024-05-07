using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cnpj { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public string razaoSocial { get; set;}

        [Required]
        public string senha { get; set; }
    }
}
