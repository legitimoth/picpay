namespace picpay;

public record UserCreateDTO
(
    string FirstName,
    string LastName,
    string Document,
    decimal Wallet,
    string Email,
    UserType Type
);
