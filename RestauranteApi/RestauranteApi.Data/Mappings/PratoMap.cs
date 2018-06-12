using RestauranteApi.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RestauranteApi.Data.Mappings
{
    public class PratoMap : EntityTypeConfiguration<Prato>
    {
        public PratoMap()
        {
            ToTable("TbPrato");

            HasKey(x => x.Id);

            Property(x => x.NomePrato)
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Preco)
                .HasPrecision(11, 2)
                .IsRequired();

            HasRequired(x => x.Restaurante);   

            
            
            
        }
    }
}
