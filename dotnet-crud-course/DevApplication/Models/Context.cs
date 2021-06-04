using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=False;Integrated Security=true;Initial Catalog=DevApplication;Server=DESKTOP-6JHF4HL\\SQLEXPRESS");
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}