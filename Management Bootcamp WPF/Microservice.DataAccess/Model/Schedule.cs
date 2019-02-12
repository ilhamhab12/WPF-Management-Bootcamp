﻿using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Schedule : BaseModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public virtual Lesson lessons { get; set; }
        public virtual Class classes { get; set; }
        public virtual Room room { get; set; }
    }
}
