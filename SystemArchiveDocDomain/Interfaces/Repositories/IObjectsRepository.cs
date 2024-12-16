namespace SystemArchiveDocDomain.Interfaces;

public interface IObjectsRepository
{
    public Task<SystemArchiveObject> GetObjectByIdAsync(Guid id);
    public Task<SystemArchiveObject> AddOrEditObjectAsync(SystemArchiveObject obj);
}