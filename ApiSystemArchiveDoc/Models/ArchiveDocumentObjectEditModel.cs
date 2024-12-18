using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveDocumentObjectEditModel
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
        }
    }
    public Dictionary<Guid,String> TaskTypes { get; set; } = new Dictionary<Guid, String>()
    {
        { Guid.NewGuid(), "ФНС" },
        { Guid.NewGuid(), "Инвентаризация" },
        { Guid.NewGuid(), "Суд" },
    }; 
    public ArchiveObjectModel ArchiveObject { get; set; } = new ArchiveObjectModel();
}