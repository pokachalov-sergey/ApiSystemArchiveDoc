namespace SystemArchiveDocDomain.Interfaces;

public interface IArchiveTaskTypesRepository
{
    public Task<List<SystemArchiveDocumentTaskType>> GetArchiveTaskTypeAsync();
    public Task<SystemArchiveDocumentTaskType> AddArchiveTaskTypeAsync(SystemArchiveDocumentTaskType obj);
}