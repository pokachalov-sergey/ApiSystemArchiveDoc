using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ArchiveTaskTypesRepository:IArchiveTaskTypesRepository
{
    SadDbContext? _db;

    public async Task<List<SystemArchiveDocumentTaskType>> GetArchiveTaskTypeAsync()
    {
        return await _db.DocumentTaskTypes.ToListAsync();
    }

    public async Task<SystemArchiveDocumentTaskType>AddArchiveTaskTypeAsync(SystemArchiveDocumentTaskType obj)
    {
        await _db.DocumentTaskTypes.AddAsync(obj);
        return obj;
    }

    public ArchiveTaskTypesRepository(SadDbContext db)
    {
        _db = db;
    }
}