using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevApplication.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Display(Name = "Descri��o")]
        [Required(ErrorMessage ="Descri��o Obrigatoria")]
        public string Descricao { get; set; }      
    }
}