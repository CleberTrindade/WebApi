using RestauranteApi.Data.Mappings;
using RestauranteApi.Domain.Entities;
using System.Data.Entity;

namespace RestauranteApi.Data.DataContexts
{
    public class RestaurantesDataContexts : DbContext
    {
        public RestaurantesDataContexts()
            : base("RestaurantesDb")
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PratoMap());
            modelBuilder.Configurations.Add(new RestauranteMap());

            modelBuilder.Entity<Restaurante>()
            .HasOptional<Prato>(s => s.Prato)
            .WithMany()
            .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }    
}
