using ApiSystemArchiveDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiSystemArchiveDoc.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
[Route("{controller}/{action}")]
public class ArchiveObjectController : Controller
{
    // GET
    public ArchiveObjectController()
    {
    }

 
    public IActionResult Index()
    {
        return View("Index",new ArchiveDocumentObjectIndexModel());
    }
   
    public IActionResult Edit()
    {
        return View("Edit",new ArchiveDocumentObjectEditModel());
    }
    public IActionResult Create()
    {
        return View("Create",new ArchiveDocumentObjectEditModel());
    }
    
    
    
}