﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentOperation
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
