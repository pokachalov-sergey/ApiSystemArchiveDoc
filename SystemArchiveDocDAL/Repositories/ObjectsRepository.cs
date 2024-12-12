using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ObjectsRepository:IObjectsRepository
{
    SadDbContext? _db;

    public async Task<SystemArchiveObject> GetObjectByIdAsync(Guid id)
    {
        return await _db.Objects.FirstOrDefaultAsync(x => x.Id == id) ?? new SystemArchiveObject();
    }

    public async Task<SystemArchiveObject> AddOrEditObjectAsync(SystemArchiveObject obj)
    {
        var archObj = _db.Objects.FirstOrDefault(x => x.Id == obj.Id);
        if (archObj != null)
        {
            archObj.Name = obj.Name;
            archObj.Description = obj.Description;
            archObj.Documents = obj.Documents;
            archObj.Address = obj.Address;
            archObj.ObjectType = obj.ObjectType;
            _db.Objects.Update(archObj);
            await _db.SaveChangesAsync();
            return archObj;
        }
        else
        {
            await _db.Objects.AddAsync(obj);
            return obj;
        }
    }

    public ObjectsRepository(SadDbContext db)
    {
        _db = db;
    }
}