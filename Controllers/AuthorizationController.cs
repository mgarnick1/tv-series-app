using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using tv_series_app.Models;
using AutoMapper;
using tv_series_app.ViewModels;
using Microsoft.AspNetCore.Identity;
using tv_series_app.Services;
using System.IdentityModel.Tokens.Jwt;

namespace tv_series_app.Controllers;

[ApiController]
[Route("api/authorize")]
public class Authorizationtroller : ControllerBase
{

    private readonly ILogger<Authorizationtroller> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly JwtHandler _jwtHandler;

    public Authorizationtroller(ILogger<Authorizationtroller> logger, IMapper mapper, UserManager<User> userManager, JwtHandler jwtHandler)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _jwtHandler = jwtHandler;
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

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Email);
        if(user == null || !await _userManager.CheckPasswordAsync(user, model.Password)) {
            return Unauthorized(new AuthResponse { Error = "Invalid Authentication" });
        }
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var userViewModel = _mapper.Map<UserViewModel>(user);
        var claims = _jwtHandler.GetClaims(user, userViewModel, user.Id);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return Ok( new AuthResponse { IsAuthSuccessful = true, Token = token });
    }

    [Authorize]
    [HttpGet]
    [Route("user")]
    public async Task<IActionResult> GetUser([FromQuery] string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if(user != null) {
            return Ok(_mapper.Map<UserTVSeriesModel>(user));
        }
        return NotFound("User not found");
    }
}
