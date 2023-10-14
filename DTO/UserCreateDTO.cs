namespace picpay;

public record UserCreateDTO
(
    string FirstName,
    string LastName,
    string Document,
    decimal Wallet,
    UserType Type
);
