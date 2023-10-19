using FullStack.API.Contracts.DTO;
using FullStack.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.API.Application.Extensions
{
    public static class EmployeeExtensions
    {
        public static IQueryable<EmployeeDto> ToDto(this IQueryable<Employee> queryable)
        {

            return queryable.Select(x => x.ToDto());
        }

        public static EmployeeDto ToDto(this Employee entity)
        {
            return new EmployeeDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Patronymic = entity.Patronymic,
                Surname = entity.Surname,
            };
        }

    }
}
