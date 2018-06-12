namespace RestauranteApi.Domain.Entities
{
    public class Restaurante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual Prato Prato { get; set; }

        public override string ToString()
        {
            return this.Nome; 
        }
    }
}
