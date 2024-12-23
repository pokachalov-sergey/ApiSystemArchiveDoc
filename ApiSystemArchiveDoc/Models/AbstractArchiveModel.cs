namespace ApiSystemArchiveDoc.Models;

public abstract class AbstractArchiveModel
{
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public  string CreateUser { get; set; }
    public DateTime? EditDateTime { get; set; }
    public string? EditUser { get; set; }
    public string StatusStr { get; set; }
    public Guid StatusId { get; set; }

}