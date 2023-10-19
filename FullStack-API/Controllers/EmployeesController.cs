using Microsoft.AspNetCore.Mvc;
using FullStack.API.Domain;
using FullStack.API.Contracts.Services;
using System.Linq.Dynamic.Core;
using FullStack.FrameWork.Common.Query;
using FullStack.API.Contracts.Filters;
using FullStack.API.Contracts.DTO;

namespace FullStack_API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesList([FromQuery] SearchQueryObject<EmployeeFilter> query, CancellationToken cancellationToken)
        {
            var employee = await _employeesService.GetList(query, cancellationToken);

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCurrentEmployee(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _employeesService.GetById(id, cancellationToken);
            
            return Ok(employee);
        }
        [HttpPatch]
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate([FromBody] EmployeeDto dto, CancellationToken cancellationToken)
        {
            var result = await _employeesService.SaveOrUpdate(dto, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCurrentEmployee(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _employeesService.Delete(id, cancellationToken);

            return Ok(employee);
        }
    }
}