using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ArchiveDoumentsRepository:IArchiveDocumentsRepository
{
    SadDbContext? _db;

    public async Task<SystemArchiveDocument> GetArchiveDocumentByIdAsync(Guid id)
    {
        return await _db.Documents.FirstOrDefaultAsync(x => x.Id == id)
               ?? new SystemArchiveDocument();
    }

    public async Task<SystemArchiveDocument> AddOrEditObjectAsync(SystemArchiveDocument obj)
    {
        var dbObj = _db.Documents.FirstOrDefault(x => x.Id == obj.Id);
        if (dbObj != null)
        {
            dbObj.Name = obj.Name;
            dbObj.Description = obj.Description;
            dbObj.Extention = obj.Extention;
            dbObj.Type = obj.Type;
            dbObj.Status = obj.Status;
            _db.Documents.Update(dbObj);
            await _db.SaveChangesAsync();
            return dbObj;
        }
        else
        {
            await _db.Documents.AddAsync(obj);
            return obj;
        }
    }

    public ArchiveDoumentsRepository(SadDbContext db)
    {
        _db = db;
    }
}