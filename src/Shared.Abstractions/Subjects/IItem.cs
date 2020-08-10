﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IItem
    {
        DateTime CreatedDate { get; set; }
        string ItemDescription { get; set; }
        Guid ItemKey { get; set; }
        string ItemName { get; set; }
        Guid ItemTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}