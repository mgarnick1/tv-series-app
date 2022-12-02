
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
[Route("api/tv-series")]
public class TVSeriesController : ControllerBase
{
    private readonly ILogger<TVSeriesController> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly ITVSeriesRepository _repository;

    public TVSeriesController(ILogger<TVSeriesController> logger, IMapper mapper, UserManager<User> userManager, ITVSeriesRepository repository)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _repository = repository;
    }


    [HttpGet]
    public async Task<IActionResult> GetTVSeries([FromQuery] int id)
    {
        return Ok(await _repository.GetTVSeries(id));
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> CreateTVSeries([FromBody] TVSeriesViewModel model)
    {
        return Ok(await _repository.AddTVSeries(model));
    }

    [HttpPut]
    [Route("edit")]
    public async Task<IActionResult> EditTVSeries([FromBody] TVSeriesViewModel model)
    {
        return Ok(await _repository.EditTVSeries(model));
    }

    [HttpGet]
    [Route("all-tvseries")]
    public async Task<IActionResult> GetAllTVSeriesByUser([FromQuery] string userId)
    {
        return Ok(await _repository.GetAllTVSeriesByUserId(userId));
    }
}