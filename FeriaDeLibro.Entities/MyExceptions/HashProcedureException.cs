using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Entities.MyExceptions
{
    public  class HashProcedureException : CryptographicException
    {
        public HashProcedureException() { }
        public HashProcedureException(string message) : base (message) { }
        public HashProcedureException(string message, Exception ex) : base (message, ex) { }

    }
}
