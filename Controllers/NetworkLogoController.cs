
using Microsoft.AspNetCore.Authorization;
using tv_series_app.Models;
using AutoMapper;
using tv_series_app.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using tv_series_app.Repositories;

namespace tv_series_app.Controllers;

[Authorize]
[ApiController]
[Route("api/network-logos")]

public class NetworkLogoController : ControllerBase
{
    private readonly ILogger<NetworkLogoController> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly INetworkLogoRepository _repository;

    public NetworkLogoController(ILogger<NetworkLogoController> logger, IMapper mapper, UserManager<User> userManager, INetworkLogoRepository repository)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTVSeries([FromQuery] string userId)
    {
        return Ok(await _repository.GetUserNetworkLogos(userId));
    }
}

