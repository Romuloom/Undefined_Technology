namespace MyLoginAPI.Models
{
    public class Metrica
    {
        public int Id { get; set; }

        public int TotalPedidosParaEntrega { get; set; }
        public int TotalProdutosCadastrados { get; set; }
        public int TotalProdutosEmEstoqueMinimo { get; set; }
        public int TotalNovosClientes { get; set; }
    }
}
