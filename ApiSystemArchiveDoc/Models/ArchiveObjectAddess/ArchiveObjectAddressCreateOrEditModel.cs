namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectAddressCreateOrEditModel
{
    public List<ArchiveObjectAddressModel> LastObjectAddresses { get; set; } = new();
    public ArchiveObjectAddressModel ArchiveObjectAddress { get; set; }
}