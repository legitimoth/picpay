namespace picpay;

public record UserDTO
(
    string FirstName,
    string LastName,
    string Document,
    decimal Wallet,
    UserType Type,
    string Email,
    Guid Id
);
