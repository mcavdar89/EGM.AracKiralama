using Infrastructure.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class LoginDto:BaseDto
    {
        public string EPosta { get; set; }
        public string Password { get; set; }
    }
}
