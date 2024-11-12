using EGM.AracKiralama.Model.Dtos;
using Infra.Model.Dtos;
using Infrastructure.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Concretes
{
    public class AuthService
    {
        public AuthService()
        {
            
        }

        public async Task<ResultDto<JwtDto>> Login(LoginDto item)
        {
            JwtDto jwtDto = new JwtDto();





            return ResultDto<JwtDto>.Success(jwtDto);
        }





    }
}
