using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocument
    {
     
        public Guid Id { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime Created { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public SystemArchiveDocumentType Type { get; set; }
        public SystemArchiveDocumentExtention Extention {  get; set; }

        public SystemArchiveDocumentStatus Status { get; set; }
        public SystemArchiveObject ArchiveObject {  get; set; }
    }
}
