using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeroAPI.Model
{
    public class Passageiro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Tamanho máximo no Nome excedido")]
        public string Nome { get; set; }
        [Range(1, 200, ErrorMessage = "Idade informada é inválida")]
        public int Idade { get; set; }
        [MaxLength(20, ErrorMessage = "Tamanho máximo excedido")]
        public string Celular { get; set; }
    }
}
