namespace SystemArchiveDocDomain.Interfaces;

public interface IArchiveAddressesRepository
{
        public Task<SystemArchiveAddress> GetArchiveAddressByIdAsync(Guid id);
        public Task<SystemArchiveAddress> AddOrEditAddressAsync(SystemArchiveAddress obj);
}