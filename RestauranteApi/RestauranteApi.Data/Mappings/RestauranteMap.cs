using RestauranteApi.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RestauranteApi.Data.Mappings
{
    public class RestauranteMap : EntityTypeConfiguration<Restaurante>
    {
        public RestauranteMap()
        {
            ToTable("TbRestaurante");

            HasKey(x => x.Id);
            Property(x => x.Nome)
                .HasMaxLength(60)
                .IsRequired();

            HasOptional(x => x.Prato);
        }
    }
}
