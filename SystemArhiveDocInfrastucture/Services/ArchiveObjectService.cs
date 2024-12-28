using SystemArchiveDocDomain;
using SystemArchiveDocDomain.Interfaces;
using SystemArchiveDocDomain.Interfaces.Services;

namespace SystemArhiveDocInfrastucture.Services;

public class ArchiveObjectService:IArchiveObjectService
{
    private IObjectsRepository _objectsRepository;
    private IArhchiveTaskTypesRepository _taskTypesRepository;
    private IArhchiveObjectTypesRepository _arhchiveObjectTypesRepository;
    private IArhchiveDocumentTypesRepository _arhchiveDocumentTypesRepository;
    public ArchiveObjectService(IObjectsRepository objectsRepository, 
        IArhchiveTaskTypesRepository taskTypesRepository, 
        IArhchiveObjectTypesRepository arhchiveObjectTypesRepository,
        IArhchiveDocumentTypesRepository arhchiveDocumentTypesRepository
        )
    {
        _objectsRepository=objectsRepository;
        _taskTypesRepository = taskTypesRepository;
        _arhchiveObjectTypesRepository = arhchiveObjectTypesRepository;
        _arhchiveDocumentTypesRepository = arhchiveDocumentTypesRepository;
    }

    public async Task<SystemArchiveObject> GetObjectById(Guid id)
    {
      return  await _objectsRepository.GetObjectByIdAsync(id);
    }
    
    public async Task<List<SystemArchiveDocumentType>> GetDocumentTypes()
    {
        return  await _arhchiveDocumentTypesRepository.GetArchiveDocumentTypesAsync();
    }
    public async Task<List<SystemArchiveObjectType>> GetObjectTypes()
    {
        return  await _arhchiveObjectTypesRepository.GetArchiveObjectTypeAsync();
    }
    
    public async Task<List<SystemArchiveDocumentTaskType>> GetTaskTypes()
    {
        return  await _taskTypesRepository.GetArchiveTaskTypeAsync();
    }
}