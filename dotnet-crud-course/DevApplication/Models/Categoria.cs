using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevApplication.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage ="Descrição Obrigatoria")]
        public string Descricao { get; set; }      
    }
}