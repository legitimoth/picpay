namespace picpay;

public record TransactionDTO
{
    public Guid Id { get; init; }
    public string? User { get; init; }
    public decimal Value { get; init; }
    public DateTime Date { get; init; }
}
