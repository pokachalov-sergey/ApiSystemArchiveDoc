using ApiSystemArchiveDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiSystemArchiveDoc.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
[Route("{controller}/{action}")]
public class ArchiveDocumentController : Controller
{
    // GET
    public ArchiveDocumentController()
    {
    }

 
    public IActionResult Index()
    {
        return View("Index",new ArchiveDocumentObjectIndexModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
   
    public IActionResult Edit()
    {
        return View("Edit",new ArchiveObjectCreateOrEditModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    public IActionResult Create()
    {
        return View("Create",new ArchiveObjectCreateOrEditModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    
    
    
}