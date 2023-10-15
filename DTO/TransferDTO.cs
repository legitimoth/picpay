namespace picpay;

public record TransferDTO
(
    Guid PayeeId,
    decimal Value
);
