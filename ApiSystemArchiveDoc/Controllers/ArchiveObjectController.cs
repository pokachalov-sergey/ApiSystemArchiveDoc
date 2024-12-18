using ApiSystemArchiveDoc.Models;
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

    public IActionResult Create()
    {
        return View(new ArchiveDocumentObjectIndexModel());
    }
    public IActionResult Edit()
    {
        return View(new ArchiveDocumentObjectIndexModel());
    }
    public IActionResult Delete()
    {
        return View(new ArchiveDocumentObjectIndexModel());
    }
    
    
    
}