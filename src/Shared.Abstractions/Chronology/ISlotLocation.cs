﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotLocation
    {
        DateTime CreatedDate { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
        Guid SlotKey { get; set; }
        Guid SlotLocationKey { get; set; }
    }
}