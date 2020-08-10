﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceItem : IResourceItem
    {
        [Key]
        public Guid ResourceItemKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ItemKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
