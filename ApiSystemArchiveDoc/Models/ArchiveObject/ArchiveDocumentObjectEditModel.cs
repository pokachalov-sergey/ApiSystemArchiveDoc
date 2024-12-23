using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveDocumentObjectEditModel:AbstractArchiveModel
{
    public ArchiveDocumentObjectEditModel()
    {
    }

    public List<SelectListItem> ObjectTypes { get; set; } = new List<SelectListItem>()
    {
        new SelectListItem()
        {
            Selected = true,
            Text = "ЗУ",
            Value = ""
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "ОКС",
            Value = ""
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "ПОМ",
            Value = ""
        },
        
    };

    public List<SelectListItem> TaskTypes { get; set; } = new List<SelectListItem>()
    {
        new SelectListItem()
        {
            Selected = true,
            Text = "ФНС",
            Value = ""
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "Инвентаризация",
            Value = ""
        },
        new SelectListItem()
        {
            Selected = false,
            Text = "Инвентаризация ФТП",
            Value = ""
        },
        
    };

    public ArchiveObjectModel ArchiveObject { get; set; } = new ArchiveObjectModel();
}