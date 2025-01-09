using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentEvent
    {
 
        public Guid Id { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime Created { get; set; }
        public  SystemArchiveDocumentOperation Operation {  get; set; }
        public string? Description { get; set; }

    }
}
