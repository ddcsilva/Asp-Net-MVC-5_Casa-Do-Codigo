using CadastroProdutos.Models;
using System.Data.Entity;

namespace CadastroProdutos.Contexts
{
    public class EFContext : DbContext
    {
        // A string enviada como argumento refere-se ao nome de uma Connection String
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        // Entitdades que são utilizadas para operações CRUD
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}