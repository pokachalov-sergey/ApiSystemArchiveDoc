using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;
using SystemArchiveDocDomain.Interfaces.Services;

namespace SystemArhiveDocInfrastucture.Services;

public class ArchiveObjectService:IArchiveObjectService
{
    private IObjectsRepository _objectsRepository;
    private IArchiveTaskTypesRepository _taskTypesRepository;
    private IArchiveObjectTypesRepository _archiveObjectTypesRepository;
    private IArhchiveDocumentTypesRepository _arhchiveDocumentTypesRepository;
    public ArchiveObjectService(IObjectsRepository objectsRepository, 
        IArchiveTaskTypesRepository taskTypesRepository, 
        IArchiveObjectTypesRepository archiveObjectTypesRepository,
        IArhchiveDocumentTypesRepository arhchiveDocumentTypesRepository
        )
    {
        _objectsRepository=objectsRepository;
        _taskTypesRepository = taskTypesRepository;
        _archiveObjectTypesRepository = archiveObjectTypesRepository;
        _arhchiveDocumentTypesRepository = arhchiveDocumentTypesRepository;
    }

    public async Task<SystemArchiveObject> CreateOrEditArchiveObjectAsync(SystemArchiveObject archiveObject)
    {
        return await _objectsRepository.AddOrEditObjectAsync(archiveObject);
        
    }

    public async Task<SystemArchiveObject> GetObjectById(Guid id)
    {
      return  await _objectsRepository.GetObjectByIdAsync(id);
    }
    
    public async Task<List<SystemArchiveObject>> GetObjectsAsync()
    {
        var objects = await _objectsRepository.GetObjects();
        return objects;
    }
    
    public async Task<List<SystemArchiveDocumentType>> GetDocumentTypesAsync()
    {
        return  await _arhchiveDocumentTypesRepository.GetArchiveDocumentTypesAsync();
    }
    public async Task<List<SystemArchiveObjectType>> GetObjectTypes()
    {
        return  await _archiveObjectTypesRepository.GetArchiveObjectTypeAsync();
    }
    
    public async Task<List<SystemArchiveDocumentTaskType>> GetTaskTypesAsync()
    {
        return  await _taskTypesRepository.GetArchiveTaskTypeAsync();
    }
}