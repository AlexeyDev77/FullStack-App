using FullStack.API.Application.Contexts;
using FullStack.API.Application.Extensions;
using FullStack.API.Contracts.DTO;
using FullStack.API.Contracts.Services;
using FullStack.API.Contracts.Filters;
using FullStack.API.Domain;
using FullStack.FrameWork.Common.Paging;
using FullStack.FrameWork.Common.Query;
using Microsoft.EntityFrameworkCore;
using FullStack.FrameWork.Common.Linq;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FullStack.API.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IDbContextFactory<MainContext> _contextFactory;

        public EmployeesService(IDbContextFactory<MainContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<PagedResult<EmployeeDto>> GetList(SearchQueryObject<EmployeeFilter> query, CancellationToken cancellationToken)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var queryable = context.Employees;

            var items = await queryable
                .PageBy(query.Paging)
                .ToDto()
                .ToListAsync(cancellationToken);

            var total = await queryable.CountAsync(cancellationToken);

            return new PagedResult<EmployeeDto>
            {
                Total = total,
                Items = items,

            };
        }

        public async Task<EmployeeDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

            var entity = await context.Employees
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            
            if (entity == null) { 
                throw new KeyNotFoundException("Employee not found");
            }

            var dto = entity.ToDto();

            return dto;
        }

        public async Task<Guid> SaveOrUpdate(EmployeeDto dto, CancellationToken cancellationToken)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

            if (dto == null)
            {
                throw new KeyNotFoundException("Employee is null");
            }

            var entity = await context.Employees
                .Where(x => x.Id == dto.Id)
                .SingleOrDefaultAsync(cancellationToken);

            entity ??= (await context.Employees.AddAsync(new Employee(), cancellationToken)).Entity;

            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Patronymic = dto.Patronymic;

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<EmployeeDto> UpdateEmployee(Guid id, Employee updatedEmployee, CancellationToken cancellationToken)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            employee.Name = updatedEmployee.Name;
            employee.Surname = updatedEmployee.Surname;
            employee.Patronymic = updatedEmployee.Patronymic;

            await context.SaveChangesAsync(cancellationToken);

            var dto = employee.ToDto();

            return dto;
        }

        public async Task<EmployeeDto> Delete(Guid id, CancellationToken cancellationToken)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync(cancellationToken);

            var dto = employee.ToDto();

            return dto;
        }
    }
}
