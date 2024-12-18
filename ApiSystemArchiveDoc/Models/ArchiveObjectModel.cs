namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectModel
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public string StatusStr { get; set; }
    public string ObjectType { get; set; }
    public ArchiveDocumentUserModel Creator;
    public List<string> ObjectTypes { get; set; }
    public double Square { get; set; }
    public string ObjectTaskType { get; set; }
    public List<string> ObjectTaskTypes { get; set; }
    public List<ArchiveDocumentOperationModel> Operations { get; set; }
    public List<ArchiveDocumentModel> Documents { get; set; }
    public string AddressStr { get; set; }
}