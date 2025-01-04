using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ArchiveObjectTypesRepository:IArchiveObjectTypesRepository
{
    SadDbContext? _db;

    public async Task<List<SystemArchiveObjectType>> GetArchiveObjectTypeAsync()
    {
        return await _db.ObjectTypes.ToListAsync();
    }

    public async Task<SystemArchiveObjectType>AddArchiveObjectTypeAsync(SystemArchiveObjectType obj)
    {
        await _db.ObjectTypes.AddAsync(obj);
        return obj;
    }

    public ArchiveObjectTypesRepository(SadDbContext db)
    {
        _db = db;
    }
}