using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SystemArchiveObjectType ObjectType {  get; set; } 

        public List<SystemArchiveDocument> Documents { get; set; }
       

    }
}
