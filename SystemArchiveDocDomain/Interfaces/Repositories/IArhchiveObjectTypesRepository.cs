namespace SystemArchiveDocDomain.Interfaces;

public interface IArhchiveObjectTypesRepository
{
    public Task<List<SystemArchiveObjectType>> GetArchiveObjectTypeAsync();
    public Task<SystemArchiveObjectType> AddArchiveObjectTypeAsync(SystemArchiveObjectType obj);
}