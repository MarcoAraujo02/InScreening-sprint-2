﻿using System.ComponentModel.DataAnnotations;

namespace InScreening_sprint_2.Models
{
    public class Funcionario
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Cpf{ get; set; }


    }
}
