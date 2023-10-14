namespace picpay;

public record UserUpdateDTO
(
    string FirstName,
    string LastName,
    string Document,
    decimal Wallet,
    UserType Type
);
