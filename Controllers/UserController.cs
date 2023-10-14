using Microsoft.AspNetCore.Mvc;

namespace picpay;

[ApiController]
[Route("Users")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <remarks>
    /// Retorna uma lista de objetos UserDTO representando todos os usuários.
    /// </remarks>
    /// <returns>Uma lista de objetos UserDTO.</returns>
    [HttpGet]
    public async Task<List<UserDTO>> GetAll()
    {
        return await _service.GetAll();
    }
}
