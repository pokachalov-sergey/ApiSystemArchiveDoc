using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveAddressPropperty
    {
    
        public Guid Id { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime Created { get; set; }

    }
}