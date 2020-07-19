﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class VentureOption
    {
        public int VentureOptionId { get; set; }
        public Guid VentureOptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Option OptionKeyNavigation { get; set; }
        public virtual Venture VentureKeyNavigation { get; set; }
    }
}
