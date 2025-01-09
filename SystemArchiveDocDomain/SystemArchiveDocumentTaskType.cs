using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentTaskType
    {
        
        public Guid Id { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime Created { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
      
    }
}