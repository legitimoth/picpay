﻿using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="userCreateDTO">Os dados do usuário a serem criados.</param>
    /// <returns>O identificador único (GUID) do usuário criado.</returns>
    [HttpPost]
    public async Task<Guid> Create(UserCreateDTO userCreateDTO)
    {
        return await _service.Create(userCreateDTO);
    }

    /// <summary>
    /// Obtém um usuário por ID.
    /// </summary>
    /// <param name="id">O identificador único (GUID) do usuário a ser recuperado.</param>
    /// <returns>Um objeto UserDTO representando o usuário encontrado.</returns>
    [HttpGet("{id}")]
    public async Task<UserDTO> GetById(Guid id)
    {
        return await _service.GetById(id);
    }
}
