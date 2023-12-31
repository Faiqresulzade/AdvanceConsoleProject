﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
