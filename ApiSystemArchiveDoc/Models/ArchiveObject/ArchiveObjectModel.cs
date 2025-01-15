using System.ComponentModel.DataAnnotations;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectModel : AbstractArchiveModel
{
    public string ObjectType { get; set; }
    public double Square { get; set; }
    public string ObjectTaskType { get; set; }
    public string StatusStr { get; set; }
    public string FullAddress { get; set; }
}