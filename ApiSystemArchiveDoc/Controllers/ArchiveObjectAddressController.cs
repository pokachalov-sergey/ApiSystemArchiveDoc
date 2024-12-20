using ApiSystemArchiveDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiSystemArchiveDoc.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
[Route("{controller}/{action}")]
public class ArchiveObjectAddressController : Controller
{
    // GET
    public ArchiveObjectAddressController()
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
    public IActionResult Delete()
    {
        return View("Create",new ArchiveDocumentObjectEditModel());
    }
    
    
    
}