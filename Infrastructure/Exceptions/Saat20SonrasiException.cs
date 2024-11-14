using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class Saat20SonrasiException:Exception
    {
        public int Errorcode { get; }
        public Saat20SonrasiException(string message) : base(message)
        {
            Errorcode = 320;
        }
    }
}
