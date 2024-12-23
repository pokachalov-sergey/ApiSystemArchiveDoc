namespace ApiSystemArchiveDoc.Models;

public class ArchiveDocumentModel:AbstractArchiveModel
{
    public string RefLink { get; set; }

    public string DocumentType { get; set; }
    public string DocumentName { get; set; }
}