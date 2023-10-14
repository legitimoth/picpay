namespace picpay;

public record UserUpdateDTO
(
    string FirstName,
    string LastName,
    string Document,
    decimal Wallet,
    string Email,
    UserType Type
);
