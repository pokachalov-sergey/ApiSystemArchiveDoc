using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
         base.OnModelCreating(builder);
         
         this.Database.ExecuteSqlRawAsync("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\"");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"Addresses\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"DocumentStatusEnumerable\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"DocumentEvents\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"ArchiveObjects\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"DocumentTaskTypes\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"DocumentTypes\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"DocumentOperations\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"ObjectTypes\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         this.Database.ExecuteSqlRawAsync("ALTER TABLE \"Documents\" ALTER COLUMN \"Id\" SET DEFAULT uuid_generate_v4()");
         
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        
    }

    
}