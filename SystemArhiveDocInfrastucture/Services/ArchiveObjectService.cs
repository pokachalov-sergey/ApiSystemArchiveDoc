using SystemArchiveDocDomain.Interfaces;
using SystemArchiveDocDomain.Interfaces.Services;

namespace SystemArchiveDocDomain.Services;

public class ArchiveObjectService:IArchiveObjectService
{
    IObjectsRepository _objectsRepository;
    public ArchiveObjectService(IObjectsRepository objectsRepository)
    {
        _objectsRepository=objectsRepository;
    }

    public async Task<SystemArchiveObject> GetObjectById(Guid id)
    {
      return  await _objectsRepository.GetObjectByIdAsync(id);
    }

}