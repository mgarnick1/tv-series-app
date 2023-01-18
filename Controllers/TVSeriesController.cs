
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
    private readonly IFileUploadRepsitory _fileUpload;
    private readonly IEmailRepository _emailRepo;

    public TVSeriesController(ILogger<TVSeriesController> logger, IMapper mapper, UserManager<User> userManager, ITVSeriesRepository repository, IFileUploadRepsitory fileUpload, IEmailRepository emailRepo)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _repository = repository;
        _fileUpload = fileUpload;
        _emailRepo = emailRepo;
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

    [HttpPost]
    [Route("upload/{userId}")]
    public async Task<IActionResult> UploadImage([FromQuery] string userId)
    {
        IFormFile form = Request.Form.Files[0];
        string url = await _fileUpload.UploadFileRetrieveLink(form.OpenReadStream(), form.FileName, userId);
        if(string.IsNullOrEmpty(url)) {
            return BadRequest("failed to upload image");
        }
        return Ok(url);
    }

    [HttpPost]
    [Route("send-message")]
    public async Task<IActionResult> SendEmail([FromBody] EmailModel email)
    {   
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        return Ok(await _emailRepo.SendEmailRecommendation(email, token));
    }
}