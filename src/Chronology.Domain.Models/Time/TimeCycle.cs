﻿using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class TimeCycle : DomainModel<ITimeCycle>, ITimeCycle
    {
        public override Guid RowKey { get { return TimeCycleKey; } set { TimeCycleKey = value; } }
        public Guid TimeCycleKey { get; set; }
        public string TimeCycleName { get; set; }
        public string TimeCycleDescription { get; set; }
        public int Days { get; set; }
        public int Interval { get; set; }
    }
}
