using AutoMapper;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.DAL.Contexts;
using Infra.DAL.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.DAL.Concretes
{
    public class LogRepository:BaseRepository, ILogRepository
    {      
        public LogRepository(AracKiralamaDbContext context, IMapper mapper):base(context,mapper)
        {
           

        }

    }
}
