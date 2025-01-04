namespace SystemArchiveDocDomain.Interfaces;

public interface IArchiveObjectTypesRepository
{
    public Task<List<SystemArchiveObjectType>> GetArchiveObjectTypeAsync();
    public Task<SystemArchiveObjectType> AddArchiveObjectTypeAsync(SystemArchiveObjectType obj);
}