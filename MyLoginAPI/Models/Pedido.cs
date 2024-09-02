public class Pedido
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow; // Garantir que seja UTC
    public string FormaPagamento { get; set; }
    public string Status { get; set; }
}
