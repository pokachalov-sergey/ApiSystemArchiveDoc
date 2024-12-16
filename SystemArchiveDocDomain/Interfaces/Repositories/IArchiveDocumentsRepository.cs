namespace SystemArchiveDocDomain.Interfaces;

public interface IArchiveDocumentsRepository
{
        public Task<SystemArchiveDocument> GetArchiveDocumentByIdAsync(Guid id);
        public Task<SystemArchiveDocument> AddOrEditObjectAsync(SystemArchiveDocument obj);
}