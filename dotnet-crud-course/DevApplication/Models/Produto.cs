using System.ComponentModel.DataAnnotations;

namespace DevApplication.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name="Descrição")]
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}