﻿
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class Government : IGovernment
    {
        public int GovernmentId { get; set; }
        public Guid GovernmentKey { get; set; }
        public string GovernmentName { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Entity GovernmentKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
    }
}
