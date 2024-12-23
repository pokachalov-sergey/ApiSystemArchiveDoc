namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectAddressCreateOrEditModel
{
    public string RefLink { get; set; }

    public List<ArchiveObjectAddressModel> LastObjectAddresses { get; set; } = new();
    public ArchiveObjectAddressModel ArchiveObjectAddress { get; set; }
}