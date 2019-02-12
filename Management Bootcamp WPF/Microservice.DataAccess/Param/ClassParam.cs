﻿using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class ClassParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Departments { get; set; }
        public int Batchs { get; set; }
        public int Employees { get; set; }
    }
}
