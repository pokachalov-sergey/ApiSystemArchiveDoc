using Microsoft.EntityFrameworkCore;
using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;

namespace SystemArchiveDocDAL.Repositories;

public class ArchiveAddressesRepository:IArchiveAddressesRepository
{
    SadDbContext? _db;

    public async Task<SystemArchiveAddress> GetArchiveAddressByIdAsync(Guid id)
    {
        return await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id)
               ?? new SystemArchiveAddress();
    }

    public async Task<SystemArchiveAddress> AddOrEditAddressAsync(SystemArchiveAddress obj)
    {
        if (await _db.Addresses.AnyAsync(x => x.Id == obj.Id))
        {
            _db.Addresses.Update(obj);
            await _db.SaveChangesAsync();
            return await _db.Addresses.FirstOrDefaultAsync(x => x.Id == obj.Id);
        }
        await _db.Addresses.AddAsync(obj);
        return obj;
    }

    public ArchiveAddressesRepository(SadDbContext db)
    {
        _db = db;
    }
}