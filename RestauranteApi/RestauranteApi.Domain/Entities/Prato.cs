namespace RestauranteApi.Domain.Entities
{
    public class Prato
    {
        public int Id { get; set; }

        public string NomePrato { get; set; }

        public decimal Preco { get; set; }

        public int RestauranteId { get; set; }

        public virtual Restaurante Restaurante { get; set; }

        public override string ToString()
        {
            return this.NomePrato;
        }
    }
}