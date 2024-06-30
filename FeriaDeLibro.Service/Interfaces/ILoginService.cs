using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Interfaces
{
    public interface ILoginService
    {
        bool Register(string username, string password);
        bool Verify(string username, string password);
    }
}
