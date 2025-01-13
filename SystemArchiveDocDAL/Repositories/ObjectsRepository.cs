using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ObjectsRepository : IObjectsRepository
{
    SadDbContext? _db;

    public async Task<SystemArchiveObject> GetObjectByIdAsync(Guid id) =>
        await _db.Objects.Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id) ?? new SystemArchiveObject();


    public async Task<List<SystemArchiveObject>> GetObjects() => await _db?.Objects
        .Include(x => x.Address)
        .ToListAsync();

    public async Task<SystemArchiveObject> AddOrEditObjectAsync(SystemArchiveObject obj)
    {
        var archObj = _db.Objects.FirstOrDefault(x => x.Id == obj.Id);
        if (archObj != null)
        {
            archObj.Documents = obj.Documents;
            archObj.Address = obj.Address;
            archObj.ObjectType = obj.ObjectType;
            archObj.TaskType = obj.TaskType;
            archObj.KadKvartal = obj.KadKvartal;
            archObj.Square = obj.Square;
            
            //archObj.Address = obj.Address;
            _db.Objects.Update(archObj);
            await _db.SaveChangesAsync();
            return archObj;
        }
        else
        {
            await _db.Objects.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
    }

    public ObjectsRepository(SadDbContext db)
    {
        _db = db;
    }
}