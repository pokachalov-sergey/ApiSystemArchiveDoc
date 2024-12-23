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
        return View("Edit",new ArchiveObjectAddressCreateOrEditModel());
    }
    public IActionResult Create()
    {
        return View("Create",new ArchiveObjectAddressCreateOrEditModel());
    }
    [HttpPost]
    public IActionResult Create(ArchiveObjectAddressCreateOrEditModel model)
    {
        return View("Create",new ArchiveObjectAddressCreateOrEditModel());
    }
    public IActionResult Delete()
    {
        return View("Create",new ArchiveObjectAddressCreateOrEditModel());
    }
    
    
    
}