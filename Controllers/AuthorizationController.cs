using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using tv_series_app.Models;
using AutoMapper;
using tv_series_app.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace tv_series_app.Controllers;

[ApiController]
[Route("api/authorize")]
public class Authorizationtroller : ControllerBase
{

    private readonly ILogger<Authorizationtroller> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public Authorizationtroller(ILogger<Authorizationtroller> logger, IMapper mapper, UserManager<User> userManager)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        List<User> users = new List<User>();
        return users;
    }

    [HttpPost]
    [Route("registration")]
    public async Task<IActionResult> RegisterUser([FromBody] UserViewModel userRequest)
    {
        if (userRequest == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var user = _mapper.Map<User>(userRequest);

        var result = await _userManager.CreateAsync(user, userRequest.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new RegistrationResponse { Errors = errors });
        }

        return StatusCode(201);
    }
}
