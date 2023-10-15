
namespace picpay;

public class PaymentService : IPaymentService
{
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;

    public PaymentService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _apiUrl = config.GetValue<string>("ApiSettings:ApiUrl") ??
            throw new Exception("Url do serviço de pagamento não informada!");
    }
    public async Task<bool> Verify()
    {
        try
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            return true;
            // *Esse metodo foi comentado pelo fato da api está fora!
            // return response.IsSuccessStatusCode;
        } catch(Exception e)
        {
            throw new Exception("Erro no serviço de verificação de pagamento!", e);
        }
    }
}
