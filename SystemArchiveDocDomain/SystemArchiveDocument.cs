namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocument
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public SystemArchiveDocumentType Type { get; set; }
        public SystemArchiveDocumentExtention Extention {  get; set; }

        public SystemArchiveDocumentStatus Status { get; set; }
        public SystemArchiveObject ArchiveObject {  get; set; }
    }
}
