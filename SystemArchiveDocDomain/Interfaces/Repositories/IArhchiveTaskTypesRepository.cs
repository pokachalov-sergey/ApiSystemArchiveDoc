namespace SystemArchiveDocDomain.Interfaces;

public interface IArhchiveTaskTypesRepository
{
    public Task<List<SystemArchiveDocumentTaskType>> GetArchiveTaskTypeAsync();
    public Task<SystemArchiveDocumentTaskType> AddArchiveTaskTypeAsync(SystemArchiveDocumentTaskType obj);
}