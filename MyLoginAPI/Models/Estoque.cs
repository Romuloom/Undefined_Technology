namespace MyLoginAPI.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
