namespace SystemArchiveDocDomain
{
    public class SystemArchiveObjectType
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public string Name {  get; set; }
        public string? Description { get; set; }
    }
}