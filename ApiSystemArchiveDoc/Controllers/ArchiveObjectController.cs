using ApiSystemArchiveDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SystemArchiveDocDAL;
using SystemArchiveDocDAL.Repositories;
using SystemArchiveDocDomain.Interfaces.Services;
using SystemArhiveDocInfrastucture.Services;

namespace ApiSystemArchiveDoc.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("{controller}/{action}")]
public class ArchiveObjectController : Controller
{
    private IArchiveObjectService _service;

    // GET
    public ArchiveObjectController()
    {
        _service = new ArchiveObjectService(new ObjectsRepository(new SadDbContext()),
            new SystemArchiveTaskTypesRepository(new SadDbContext()),
            new SystemArchiveObjectTypesRepository(new SadDbContext()),
            new SystemArchiveDocumentTypesRepository(new SadDbContext()));
    }


    public IActionResult Index()
    {
        return View("Index", new ArchiveDocumentObjectIndexModel()
        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }

    public async Task<IActionResult> Edit()
    {
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var taskTypes = (await _service.GetTaskTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var documentTypes = (await _service.GetDocumentTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        return View("Edit", new ArchiveDocumentObjectEditModel()
        {
            ObjectTypes = objectTypes.ToList(),
            TaskTypes = taskTypes.ToList(),
            DocumentTypes = documentTypes.ToList(),
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });


        var taskTypes = (await _service.GetTaskTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var documentTypes = (await _service.GetDocumentTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });

        return View("Create", new ArchiveDocumentObjectEditModel()
        {
            ObjectTypes = objectTypes.ToList(),
            TaskTypes = taskTypes.ToList(),
            DocumentTypes = documentTypes.ToList(),

            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArchiveDocumentObjectEditModel model)
    {
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });


        var taskTypes = (await _service.GetTaskTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var documentTypes = (await _service.GetDocumentTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });

        if (!ModelState.IsValid)

            return View("Create", new ArchiveDocumentObjectEditModel()
            {
                ObjectTypes = objectTypes.ToList(),
                TaskTypes = taskTypes.ToList(),
                DocumentTypes = documentTypes.ToList(),

                RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
            });
        else
        {
            return View("Create", new ArchiveDocumentObjectEditModel()
            {
                ObjectTypes = objectTypes.ToList(),
                TaskTypes = taskTypes.ToList(),
                DocumentTypes = documentTypes.ToList(),

                RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
            });
        }
    }
}