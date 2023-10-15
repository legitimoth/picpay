namespace picpay;

public class Transaction
{
    public Guid Id { get; private set; }
    public User? Payer { get; private set; }
    public Guid PayerId { get; private set; }
    public User? Payee { get; private set; }
    public Guid PayeeId { get; private set; }
    public decimal Value { get; private set; }
    public DateTime Date { get; private set; }

    public Transaction(
        Guid payerId,
        Guid payeeId,
        decimal value,
        Guid id = default
    )
    {
        PayerId = payerId;
        PayeeId = payeeId;
        Value = value;
        Date = DateTime.UtcNow;
    }
}
