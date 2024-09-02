namespace MyLoginAPI.Models
{
    public class ListaEscolar
    {
        public int Id { get; set; }
        public string NomeEscola { get; set; }
        public string Produtos { get; set; } // Pode ser uma lista ou string delimitada por vírgulas
    }
}
