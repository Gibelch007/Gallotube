using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gallotube.Models;
using Gallotube.Interfaces;


namespace Gallotube.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVideoRepository _videoRepository;

    public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepository)
    {
        _logger = logger;
        _videoRepository = movieRepository;
    }

    public IActionResult Index()
    {
        var videos = _videoRepository.ReadAll();
        return View(videos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError("Ocorreu um erro");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
