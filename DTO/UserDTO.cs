namespace picpay;

public record UserDTO
(
    string FirstName,
    string LastName,
    string Document,
    decimal Wallet,
    UserType Type,
    Guid Id
);
