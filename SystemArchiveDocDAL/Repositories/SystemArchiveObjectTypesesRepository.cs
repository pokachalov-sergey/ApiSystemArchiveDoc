using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class SystemArchiveObjectTypesRepository:IArhchiveObjectTypesRepository
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

    public SystemArchiveObjectTypesRepository(SadDbContext db)
    {
        _db = db;
    }
}