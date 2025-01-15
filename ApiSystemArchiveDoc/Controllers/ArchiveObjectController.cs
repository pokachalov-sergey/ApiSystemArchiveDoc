using ApiSystemArchiveDoc.Models;
using ApiSystemArchiveDoc.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.SwaggerGen;
using SystemArchiveDocDAL;
using SystemArchiveDocDAL.Repositories;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces.Services;
using SystemArhiveDocInfrastucture.Services;

namespace ApiSystemArchiveDoc.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("{controller}/{action}")]
public class ArchiveObjectController : Controller
{
    private IArchiveObjectService _service;

    // GET
    public ArchiveObjectController(IArchiveObjectService service)
    {
        _service = service;
    }


    public async Task<IActionResult> Index()
    {
        var u = (User.Identity as ApiSystemArchiveDocUser);
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var taskTypes = (await _service.GetTaskTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var documentTypes = (await _service.GetDocumentTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        return View("Index", new ArchiveDocumentObjectIndexModel()
        {
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
            ArchiveObjects = (await _service.GetObjectsAsync()).Select(o =>
                new ArchiveObjectModel()
                {
                    Id = o.Id,
                    Square = o.Square.Value,
                    FullAddress = o.Address.FullAddress,
                    ObjectType = o.ObjectType.Name,
                    ObjectTaskType = o.TaskType.Name,
                    CreateDateTime = o.Created,
                    StatusStr = o.Status.Name
                }).ToList()
        });
    }

    #region Create

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });


        var taskTypes = (await _service.GetTaskTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var documentTypes = (await _service.GetDocumentTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        ViewData["Action"] = "Create";

        return View("CreateOrEdit", new ArchiveObjectCreateOrEditModel()
        {
            ObjectTypes = objectTypes.ToList(),
            TaskTypes = taskTypes.ToList(),
            DocumentTypes = documentTypes.ToList(),
            StatusStr = "Без статуса",
            StatusCodeStr = "01",
            Region = "Донецкая Народная Респ",
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArchiveObjectCreateOrEditModel model)
    {
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var taskTypes = (await _service.GetTaskTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        var documentTypes = (await _service.GetDocumentTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });

        if (ModelState.IsValid)
        {
            var archiveObject = await _service.CreateOrEditArchiveObjectAsync(
                new SystemArchiveObject()
                {
                    Created = DateTime.Now,
                    Square = model.Square,
                    Status = (await _service.GetStatusesAsync()).First(x => x.Code == "20"),
                    Address = new SystemArchiveAddress()
                    {
                        Region = model.Region,
                        Area = model.Area,
                        City = model.City,
                        CityArea = model.CityArea,
                        CityDistrict = model.CityDistrict,
                        Settlement = model.Settlement,
                        Street = model.Street,
                        House = model.House,
                        Block = model.Block,
                        Floor = model.Floor,
                        Flat = model.Flat,
                        Stead = model.Stead,
                        Okato = model.Okato,
                        Oktmo = model.Oktmo,
                        GeoLat = model.GeoLat,
                        GeoLon = model.GeoLon,
                        FullAddress = @$"{model.KadKvartal} {(await _service.GetObjectTypes())
                            .FirstOrDefault(x => x.Id.ToString() == model.ObjectType)?.Name} "
                                      + $@"{model.Region},"
                                      + (string.IsNullOrEmpty(model.Area) ? string.Empty : model.Area + ",")
                                      + (string.IsNullOrEmpty(model.City) ? string.Empty : model.City + ",")
                                      + (string.IsNullOrEmpty(model.CityArea) ? string.Empty : model.CityArea + ",")
                                      + (string.IsNullOrEmpty(model.CityDistrict)
                                          ? string.Empty
                                          : model.CityDistrict + ",")
                                      + (string.IsNullOrEmpty(model.Settlement) ? string.Empty : model.Settlement + ",")
                                      + (string.IsNullOrEmpty(model.House) ? string.Empty : "д. " + model.House + ",")
                                      + (string.IsNullOrEmpty(model.Block) ? string.Empty : "" + model.Block + ",")
                                      + (string.IsNullOrEmpty(model.Floor) ? string.Empty : "этаж " + model.Floor + ",")
                                      + (string.IsNullOrEmpty(model.Flat) ? string.Empty : "кв. " + model.Flat + ",")
                                      + (string.IsNullOrEmpty(model.Flat)
                                          ? string.Empty
                                          : "з.у. номер. " + model.Flat + ",")
                    },

                    ObjectType =
                        (await _service.GetObjectTypes()).FirstOrDefault(x => x.Id.ToString() == model.ObjectType),
                    TaskType = (await _service.GetTaskTypesAsync()).FirstOrDefault(x =>
                        x.Id.ToString() == model.ObjectTaskType),
                    KadKvartal = model.KadKvartal,
                });
            if (Guid.Empty != archiveObject.Id || archiveObject.Id != null)
               return RedirectToAction("Edit", new {Id = archiveObject.Id.ToString()});

        }
       

        return View("CreateOrEdit", new ArchiveObjectCreateOrEditModel()
        {
            ObjectTypes = objectTypes.ToList(),
            TaskTypes = taskTypes.ToList(),
            DocumentTypes = documentTypes.ToList(),

            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
        });
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(string Id)
    {
        var u = (User.Identity as ApiSystemArchiveDocUser);

        var archiveObject = await _service.GetObjectById(Guid.Parse(Id));


        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = x.Id == archiveObject.ObjectType.Id
        });
        var taskTypes = (await _service.GetTaskTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = x.Id == archiveObject.TaskType.Id
        });
        var documentTypes = (await _service.GetDocumentTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        ViewData["Action"] = "Edit";
        return View("CreateOrEdit", new ArchiveObjectCreateOrEditModel()
        {
            StatusStr = archiveObject.Status.Name,
            StatusCodeStr = archiveObject.Status.Code,
            ObjectTypes = objectTypes.ToList(),
            TaskTypes = taskTypes.ToList(),
            DocumentTypes = documentTypes.ToList(),
            KadKvartal = archiveObject.KadKvartal,
            ObjectType = archiveObject.ObjectType.Id.ToString(),
            ObjectTaskType = archiveObject.TaskType.Id.ToString(),
            Square = archiveObject.Square.Value,
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
            Region = archiveObject.Address.Region,
            Area = archiveObject.Address.Area,
            City = archiveObject.Address.City,
            CityArea = archiveObject.Address.CityArea,
            CityDistrict = archiveObject.Address.CityDistrict,
            Settlement = archiveObject.Address.Settlement,
            Street = archiveObject.Address.Street,
            House = archiveObject.Address.House,
            Block = archiveObject.Address.Block,
            Floor = archiveObject.Address.Floor,
            Flat = archiveObject.Address.Flat,
            Stead = archiveObject.Address.Stead,
            Okato = archiveObject.Address.Okato,
            Oktmo = archiveObject.Address.Oktmo,
            GeoLat = archiveObject.Address.GeoLat,
            GeoLon = archiveObject.Address.GeoLon,
            FullAddress = archiveObject.Address.FullAddress
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ArchiveObjectCreateOrEditModel model)
    {
        var u = (User.Identity as ApiSystemArchiveDocUser);
        ViewData["Action"] = "Edit";

        var archiveObject = await _service.GetObjectById(model.Id);
        var objectTypes = (await _service.GetObjectTypes()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = x.Id == archiveObject.ObjectType.Id
        });
        var taskTypes = (await _service.GetTaskTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = x.Id == archiveObject.TaskType.Id
        });
        var documentTypes = (await _service.GetDocumentTypesAsync()).Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        if (ModelState.IsValid)
        {
            SystemArchiveAddress address = (archiveObject.Address != null
                                            && Guid.Empty != archiveObject.Address.Id)
                ? archiveObject.Address
                : new SystemArchiveAddress();
            address.Region = model.Region;
            address.Area = model.Area;
            address.City = model.City;
            address.CityArea = model.CityArea;
            address.CityDistrict = model.CityDistrict;
            address.Settlement = model.Settlement;
            address.Street = model.Street;
            address.House = model.House;
            address.Block = model.Block;
            address.Floor = model.Floor;
            address.Flat = model.Flat;
            address.Stead = model.Stead;
            address.Okato = model.Okato;
            address.Oktmo = model.Oktmo;
            address.GeoLat = model.GeoLat;
            address.GeoLon = model.GeoLon;
            address.FullAddress = @$"{model.KadKvartal} {(await _service.GetObjectTypes())
                .FirstOrDefault(x => x.Id.ToString() == model.ObjectType)?.Name} "
                                  + $@"{model.Region},"
                                  + (string.IsNullOrEmpty(model.Area) ? string.Empty : model.Area + ",")
                                  + (string.IsNullOrEmpty(model.City) ? string.Empty : model.City + ",")
                                  + (string.IsNullOrEmpty(model.CityArea) ? string.Empty : model.CityArea + ",")
                                  + (string.IsNullOrEmpty(model.CityDistrict)
                                      ? string.Empty
                                      : model.CityDistrict + ",")
                                  + (string.IsNullOrEmpty(model.Settlement)
                                      ? string.Empty
                                      : model.Settlement + ",")
                                  + (string.IsNullOrEmpty(model.House)
                                      ? string.Empty
                                      : "д. " + model.House + ",")
                                  + (string.IsNullOrEmpty(model.Block) ? string.Empty : "" + model.Block + ",")
                                  + (string.IsNullOrEmpty(model.Floor)
                                      ? string.Empty
                                      : "этаж " + model.Floor + ",")
                                  + (string.IsNullOrEmpty(model.Flat)
                                      ? string.Empty
                                      : "кв. " + model.Flat + ",")
                                  + (string.IsNullOrEmpty(model.Flat)
                                      ? string.Empty
                                      : "з.у. номер. " + model.Flat + ",");

            archiveObject = await _service.CreateOrEditArchiveObjectAsync(
                new SystemArchiveObject()
                {
                    Id = archiveObject.Id,
                    Created = archiveObject.Created,
                    Square = model.Square,
                    Address = address,
                    ObjectType =
                        (await _service.GetObjectTypes()).FirstOrDefault(x => x.Id.ToString() == model.ObjectType),
                    TaskType = (await _service.GetTaskTypesAsync()).FirstOrDefault(x =>
                        x.Id.ToString() == model.ObjectTaskType),
                    KadKvartal = model.KadKvartal,
                });
            if (Guid.Empty != archiveObject.Id || archiveObject.Id != null)
                return RedirectToAction("Edit", new {Id = archiveObject.Id.ToString()});

            return RedirectToAction("Index"
                    );

        }

        return View("CreateOrEdit", new ArchiveObjectCreateOrEditModel()
        {
            StatusStr = archiveObject.Status.Name,
            StatusCodeStr = archiveObject.Status.Code,
            ObjectTypes = objectTypes.ToList(),
            TaskTypes = taskTypes.ToList(),
            DocumentTypes = documentTypes.ToList(),
            KadKvartal = archiveObject.KadKvartal,
            ObjectType = archiveObject.ObjectType.Name,
            ObjectTaskType = archiveObject.TaskType.Name,
            Square = archiveObject.Square.Value,
            RefLink = HttpContext.Request.Path + HttpContext.Request.QueryString.Value,
            Region = archiveObject.Address.Region,
            Area = archiveObject.Address.Area,
            City = archiveObject.Address.City,
            CityArea = archiveObject.Address.CityArea,
            CityDistrict = archiveObject.Address.CityDistrict,
            Settlement = archiveObject.Address.Settlement,
            Street = archiveObject.Address.Street,
            House = archiveObject.Address.House,
            Block = archiveObject.Address.Block,
            Floor = archiveObject.Address.Floor,
            Flat = archiveObject.Address.Flat,
            Stead = archiveObject.Address.Stead,
            Okato = archiveObject.Address.Okato,
            Oktmo = archiveObject.Address.Oktmo,
            GeoLat = archiveObject.Address.GeoLat,
            GeoLon = archiveObject.Address.GeoLon,
            FullAddress = archiveObject.Address.FullAddress
        });
    }

    #endregion


    [HttpGet]
    public async Task<List<ArchiveObjectModel>> GetSimilarObject(string Id)
    {
        var u = (User.Identity as ApiSystemArchiveDocUser);
        var archiveObject = await _service.GetObjectById(Guid.Parse(Id));
        return (await _service.GetObjectsAsync())
            .Select(o => new ArchiveObjectModel()
            {
                ObjectType = o.ObjectType.Name,
                Square = o.Square.Value,
                ObjectTaskType = o.TaskType.Name,
                StatusStr = o.Status.Name,
                FullAddress = o.Address.FullAddress
            })
            .ToList();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetObjectToChecked(string Id)
    {
        var archiveObject = await _service.GetObjectById(Guid.Parse(Id));
        archiveObject.Status = (await _service.GetStatusesAsync()).First(x => x.Code == "25");
        _service.CreateOrEditArchiveObjectAsync(archiveObject);
        return Ok();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetObjectToDouble(string Id, string KadNum)
    {
        var archiveObject = await _service.GetObjectById(Guid.Parse(Id));
        archiveObject.Status = (await _service.GetStatusesAsync()).First(x => x.Code == "21");
        _service.CreateOrEditArchiveObjectAsync(archiveObject);
        return Ok();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetObjectToClosed(string Id)
    {
        var archiveObject = await _service.GetObjectById(Guid.Parse(Id));
        archiveObject.Status = (await _service.GetStatusesAsync()).First(x => x.Code == "40");
        _service.CreateOrEditArchiveObjectAsync(archiveObject);
        return Ok();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetObjectToStop(string Id)
    {
        var archiveObject = await _service.GetObjectById(Guid.Parse(Id));
        archiveObject.Status = (await _service.GetStatusesAsync()).First(x => x.Code == "50");
        _service.CreateOrEditArchiveObjectAsync(archiveObject);
        return Ok();
    }
    
    

}