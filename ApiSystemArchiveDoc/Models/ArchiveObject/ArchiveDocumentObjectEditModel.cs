using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveDocumentObjectEditModel : AbstractArchiveModel
{
    public string RefLink { get; set; }


    public List<SelectListItem> ObjectTypes { get; set; }

    public List<SelectListItem> TaskTypes { get; set; }
    public List<SelectListItem> DocumentTypes { get; set; }

    public ArchiveObjectModel ArchiveObject { get; set; } = new ArchiveObjectModel();
}