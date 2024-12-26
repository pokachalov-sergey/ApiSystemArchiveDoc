using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveDocumentObjectEditModel:AbstractArchiveModel
{
    public string RefLink { get; set; }

   

    public List<SelectListItem> ObjectTypes { get; set; } = new List<SelectListItem>()
    {
        new SelectListItem()
        {
            Selected = true,
            Text = "ЗУ",
            Value = Guid.NewGuid().ToString()
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "ОКС",
            Value =Guid.NewGuid().ToString()
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "ПОМ",
            Value =Guid.NewGuid().ToString()
        },
        
    };

    public List<SelectListItem> TaskTypes { get; set; } = new List<SelectListItem>()
    {
        new SelectListItem()
        {
            Selected = true,
            Text = "ФНС",
            Value = Guid.NewGuid().ToString()
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "Инвентаризация",
            Value = Guid.NewGuid().ToString()
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "Инвентаризация ФТП",
            Value = Guid.NewGuid().ToString()
        },
        
    };

    public ArchiveObjectModel ArchiveObject { get; set; } = new ArchiveObjectModel();
}