namespace SystemArchiveDocDomain.Interfaces;

public interface IArhchiveDocumentTypesRepository
{
    public Task<List<SystemArchiveDocumentType>> GetArchiveDocumentTypesAsync();
    public Task<SystemArchiveDocumentType> AddArchiveDocumentTypeAsync(SystemArchiveDocumentType obj);
}