using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentStatus
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime Created { get; set; }

    }
}
