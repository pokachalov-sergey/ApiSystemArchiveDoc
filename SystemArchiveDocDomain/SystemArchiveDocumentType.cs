namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SystemArchiveDocumentType(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}