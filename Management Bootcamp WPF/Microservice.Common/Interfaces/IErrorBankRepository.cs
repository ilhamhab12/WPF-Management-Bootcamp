﻿using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IErrorBankRepository
    {
        bool Insert(ErrorBankParam errorBankParam);
        bool Update(int? id, ErrorBankParam errorBankParam);
        bool Delete(int? id);
        List<ErrorBank> Get();
        ErrorBank Get(int? id);
        List<ErrorBank> Search(string keywoard, string category);
    }
}
