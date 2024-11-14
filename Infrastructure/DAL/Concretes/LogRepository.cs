using AutoMapper;
using Infra.DAL.Abstracts;
using Infra.DAL.Contexts;

namespace Infra.DAL.Concretes
{
    public class LogRepository:BaseRepository, ILogRepository
    {      
        public LogRepository(LogDBContext context, IMapper mapper):base(context,mapper)
        {
           

        }

    }
}
