namespace SystemArchiveDocDomain.Interfaces.Services;

public interface IArchiveObjectService
{
    Task<List<SystemArchiveDocumentType>> GetDocumentTypesAsync();

    Task<List<SystemArchiveObjectType>> GetObjectTypes();


    Task<List<SystemArchiveDocumentTaskType>> GetTaskTypesAsync();

    Task<SystemArchiveObject> CreateOrEditArchiveObjectAsync(SystemArchiveObject archiveObject);

    Task<SystemArchiveObject> GetObjectById(Guid id);
    Task<List<SystemArchiveObject>> GetObjectsAsync();

    Task<List<SystemArchiveDocumentStatus>> GetStatusesAsync();
}