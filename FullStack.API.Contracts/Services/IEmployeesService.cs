using FullStack.API.Contracts.DTO;
using FullStack.API.Contracts.Filters;
using FullStack.FrameWork.Common.Paging;
using FullStack.FrameWork.Common.Query;

namespace FullStack.API.Contracts.Services
{
    public interface IEmployeesService
    {
        Task<EmployeeDto> GetById(Guid id, CancellationToken cancellationToken);
        Task<PagedResult<EmployeeDto>> GetList(SearchQueryObject<EmployeeFilter> query, CancellationToken cancellationToken);
        Task<Guid> SaveOrUpdate(EmployeeDto dto, CancellationToken cancellationToken);
        Task<EmployeeDto> Delete(Guid id, CancellationToken cancellationToken);
    }
}