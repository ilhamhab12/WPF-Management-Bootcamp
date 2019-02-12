using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface ILoginRepository
    {
        Employee GetEmployee(string username);
        Student GetStudent(string username);
    }
}
