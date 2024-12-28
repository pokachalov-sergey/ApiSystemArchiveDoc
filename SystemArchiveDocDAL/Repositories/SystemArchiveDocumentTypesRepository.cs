using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class SystemArchiveDocumentTypesRepository:IArhchiveDocumentTypesRepository
{
    SadDbContext? _db;
  
    public SystemArchiveDocumentTypesRepository(SadDbContext db)
    {
        _db = db;
    }

    public async Task<List<SystemArchiveDocumentType>> GetArchiveDocumentTypesAsync()
    {
        return await _db.DocumentTypes.ToListAsync();

    }

    public async Task<SystemArchiveDocumentType> AddArchiveDocumentTypeAsync(SystemArchiveDocumentType obj)
    {
        await _db.DocumentTypes.AddAsync(obj);
        return obj;
    }
}