﻿using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface ILevelService
    {
        bool Insert(LevelParam levelParam);
        bool Update(int? id, LevelParam levelParam);
        bool Delete(int? id);
        List<Level> Get();
        Level Get(int? id);
        List<Level> Search(string keywoard, string category);
    }
}
