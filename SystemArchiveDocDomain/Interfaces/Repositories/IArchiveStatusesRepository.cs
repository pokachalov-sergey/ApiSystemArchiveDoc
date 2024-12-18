namespace SystemArchiveDocDomain.Interfaces;

public interface IArchiveStatusesRepository
{
    public Task<List<SystemArchiveDocumentStatus>> GetArchiveStatusesAsync();
    public Task<SystemArchiveDocumentStatus> AddStatusAsync(SystemArchiveDocumentStatus obj);
}