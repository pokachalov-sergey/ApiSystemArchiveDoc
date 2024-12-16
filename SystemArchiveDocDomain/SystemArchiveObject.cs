using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveObject
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public SystemArchiveDocumentStatus Status { get; set; }
        
        public SystemArchiveObjectType ObjectType { get; set; }
        public List<SystemArchiveDocument> Documents { get; set; }
        public SystemArchiveAddress Address { get; set; }
        
        public double? Square { get; set; }
        
        
    }
}