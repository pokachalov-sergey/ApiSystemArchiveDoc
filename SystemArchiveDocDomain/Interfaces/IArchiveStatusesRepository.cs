namespace SystemArchiveDocDomain.Interfaces;

public interface IArchiveStatusesRepository
{
    public Task<List<SystemArchiveDocumentStatus>> GetArchiveStatusesAsync(Guid id);
    public Task<SystemArchiveDocumentStatus> AddStatusAsync(SystemArchiveDocumentStatus obj);
}