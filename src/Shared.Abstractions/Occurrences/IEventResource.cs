﻿using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventResource
    {
        DateTime CreatedDate { get; set; }
        Guid EventKey { get; set; }
        Guid EventResourceKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
    }
}