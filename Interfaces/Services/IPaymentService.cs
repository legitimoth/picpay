namespace picpay;

public interface IPaymentService
{
    public Task<bool> Verify();
}
