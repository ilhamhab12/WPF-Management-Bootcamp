﻿using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IBatchService
    {
        bool Insert(BatchParam batchParam);
        bool Update(int? id, BatchParam batchParam);
        bool Delete(int? id);
        List<Batch> Get();
        Batch Get(int? id);
        List<Batch> Search(string keywoard, string category);
    }
}
