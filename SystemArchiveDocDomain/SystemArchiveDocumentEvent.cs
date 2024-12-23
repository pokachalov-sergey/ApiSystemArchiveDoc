﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArchiveDocDomain
{
    public class SystemArchiveDocumentEvent
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public DateTime EventDate {  get; set; }
        public  SystemArchiveDocumentOperation Operation {  get; set; }
        public string? Description { get; set; }

    }
}
