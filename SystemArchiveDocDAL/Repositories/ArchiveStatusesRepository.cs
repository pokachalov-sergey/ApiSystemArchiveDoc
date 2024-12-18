using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ArchiveStatusesRepository:IArchiveStatusesRepository
{
    SadDbContext? _db;

    public async Task<List<SystemArchiveDocumentStatus>> GetArchiveStatusesAsync()
    {
        return await _db.DocumentStatusEnumerable.ToListAsync();
    }

    public async Task<SystemArchiveDocumentStatus>AddStatusAsync(SystemArchiveDocumentStatus obj)
    {
        await _db.DocumentStatusEnumerable.AddAsync(obj);
        return obj;
    }

    public ArchiveStatusesRepository(SadDbContext db)
    {
        _db = db;
    }
}