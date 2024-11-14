using Infra.BL.Abstracts;
using Infra.DAL.Abstracts;
using Infra.Model.Entities;

namespace Infra.BL.Concretes
{
    public class LogService:ILogService
    {
        ILogRepository _repository;

        public LogService(ILogRepository repository)
        {
            _repository = repository;
        }

        public async Task AddLogAsync(LogTable log)
        {
            await _repository.AddAsync(log);
            await _repository.SaveChangesAsync();
        }
        public async Task AddErrorLogAsync(ErrorLogTable log)
        {
            _repository.Clear();
            await _repository.AddAsync(log);
            await _repository.SaveChangesAsync();
        }




    }
}
