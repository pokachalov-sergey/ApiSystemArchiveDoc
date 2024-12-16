using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiSystemArchiveDoc.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
public class ArchiveObjectController : Controller
{
    // GET
    public ArchiveObjectController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }
    
    
}