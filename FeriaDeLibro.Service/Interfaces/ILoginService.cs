using FeriaDeLibro.Entities.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Interfaces
{
    public interface ILoginService
    {
        Result<bool> Register(string username, string password);
        Result<int> Verify(string username, string password);
    }
}
