using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveObject
    {
    
        public Guid Id { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime Created { get; set; }


        public SystemArchiveDocumentStatus Status { get; set; }

        public SystemArchiveDocumentTaskType TaskType {  get; set; }
        public SystemArchiveObjectType ObjectType { get; set; }
        public List<SystemArchiveDocument> Documents { get; set; }
        public SystemArchiveAddress Address { get; set; }
        
        public double? Square { get; set; }
        
        public string KadKvartal { get; set; }
        
    }
}