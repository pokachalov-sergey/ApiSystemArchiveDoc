using ApiSystemArchiveDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiSystemArchiveDoc.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
[Route("{controller}/{action}")]
public class ArchiveObjectAddressController : Controller
{
   
    public IActionResult Edit(Guid id)
    {
        return View("Edit",new ArchiveObjectAddressCreateOrEditModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    public IActionResult Create()
    {
        return View("Create",new ArchiveObjectAddressCreateOrEditModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    [HttpPost]
    public IActionResult Create(ArchiveObjectAddressCreateOrEditModel model)
    {
        return View("Create",new ArchiveObjectAddressCreateOrEditModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    public IActionResult Delete()
    {
        return View("Create",new ArchiveObjectAddressCreateOrEditModel()        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }
    
    
    
}