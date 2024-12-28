namespace SystemArchiveDocDomain.Interfaces.Services;

public interface IArchiveObjectService
{
    Task<List<SystemArchiveDocumentType>> GetDocumentTypes();

    Task<List<SystemArchiveObjectType>> GetObjectTypes();


    Task<List<SystemArchiveDocumentTaskType>> GetTaskTypes();

}