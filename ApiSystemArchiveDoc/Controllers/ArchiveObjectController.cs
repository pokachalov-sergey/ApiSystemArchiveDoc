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
        return View("Index",new ArchiveDocumentObjectIndexModel()
        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
   
    public IActionResult Edit()
    {
        return View("Edit",new ArchiveDocumentObjectEditModel()
        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    [HttpGet]
    public IActionResult Create()
    {
       
        return View("Create",new ArchiveDocumentObjectEditModel()
        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ArchiveDocumentObjectEditModel model)
    {
        if (!ModelState.IsValid)
           
        return View("Create",new ArchiveDocumentObjectEditModel()
        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
        else
        {
                 
            return View("Create",new ArchiveDocumentObjectEditModel()
            {
                RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
            });
        }
    }
    
    
    
}