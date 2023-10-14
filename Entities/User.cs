namespace picpay;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public decimal Wallet { get; set; }
    public UserType Type { get; set; }
    public bool Active { get; set; }
}
