namespace ApiSystemArchiveDoc.Models;

public class ArchiveDocumentObjectIndexModel:AbstractArchiveModel
{
    public ArchiveDocumentObjectIndexModel()
    {
        ArchiveObjects = new List<ArchiveObjectModel>();
    }
    public List<ArchiveObjectModel> ArchiveObjects { get; set; } = new List<ArchiveObjectModel>();
}