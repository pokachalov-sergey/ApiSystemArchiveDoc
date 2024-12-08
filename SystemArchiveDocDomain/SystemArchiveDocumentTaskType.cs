namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentTaskType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SystemArchiveDocumentTaskType(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}