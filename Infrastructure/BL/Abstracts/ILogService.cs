using Infra.Model.Entities;

namespace Infra.BL.Abstracts
{
    public interface ILogService
    {
        Task AddLogAsync(LogTable log);
    }
}
