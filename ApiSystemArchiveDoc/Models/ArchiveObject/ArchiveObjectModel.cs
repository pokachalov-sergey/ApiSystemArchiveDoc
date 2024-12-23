namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectModel: AbstractArchiveModel
{
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public  string CreateUser { get; set; }
    public DateTime? EditDateTime { get; set; }
    public string? EditUser { get; set; }
    public string StatusStr { get; set; }
    public Guid StatusId { get; set; }
    
    public string ObjectType { get; set; }
    
    public ArchiveDocumentUserModel Creator;
    
    public List<string> ObjectTypes { get; set; }
    public double Square { get; set; }
    public string ObjectTaskType { get; set; }
    public List<string> ObjectTaskTypes { get; set; }
    public List<ArchiveDocumentOperationModel> Operations { get; set; }
    public List<ArchiveDocumentModel> Documents { get; set; } = new List<ArchiveDocumentModel>();
    
   public  ArchiveObjectAddressModel Address { get; set; }
}