using Microsoft.AspNetCore.Mvc;

namespace ApiSystemArchiveDoc.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}