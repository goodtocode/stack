﻿using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotTimeRange
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid SlotKey { get; set; }
        Guid SlotTimeRangeKey { get; set; }
        Guid TimeRangeKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}