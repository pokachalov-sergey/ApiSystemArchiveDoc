using SystemArchiveDocDomain.Interfaces;

namespace ClassLibrary1.Services;

public class ArchiveObjectService
{
    IObjectsRepository _objectsRepository;
    public ArchiveObjectService(IObjectsRepository objectsRepository)
    {
        _objectsRepository=objectsRepository;
    }
    
    public 
}