using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL;

public class SadDbContext : DbContext
{
    public DbSet<SystemArchiveObject> Objects { get; set; } = null!;
    public DbSet<SystemArchiveDocument> Documents { get; set; } = null!;
    public DbSet<SystemArchiveObjectType> ObjectTypes { get; set; } = null!; 
    // public DbSet<SystemArchiveAddressPropperty> AddressPropperties { get; set; } = null!;
  //  public DbSet<SystemArchiveDocDomain.SystemArchiveDocumentExtention> Objects { get; set; } = null!;
    public DbSet<SystemArchiveDocumentOperation> DocumentOperations { get; set; } = null!;
    public DbSet<SystemArchiveDocumentType> DocumentTypes { get; set; } = null!;
    public DbSet<SystemArchiveDocumentTaskType> DocumentTaskTypes { get; set; } = null!;
    public DbSet<SystemArchiveObject> ArchiveObjects { get; set; } = null!;
    public DbSet<SystemArchiveDocumentEvent> DocumentEvents { get; set; } = null!;
    public DbSet<SystemArchiveDocumentStatus> DocumentStatusEnumerable  { get; set; } = null!;
    public DbSet<SystemArchiveAddress> Addresses { get; set; } = null!;
    public SadDbContext()
    {
        Database.EnsureCreated();
    }
   
    
    public SadDbContext(DbContextOptions<SadDbContext> options)
        : base(options)
    {
       
    }

}