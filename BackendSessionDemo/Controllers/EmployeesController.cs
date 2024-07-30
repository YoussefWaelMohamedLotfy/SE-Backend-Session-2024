using Application;
using BackendSessionDemo.Data;
using BackendSessionDemo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendSessionDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly GuidService _guidService;

    public EmployeesController(IEmployeeService employeeService, GuidService guidService)
    {
        _employeeService = employeeService;
        _guidService = guidService;
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        Console.WriteLine($"Guid value in Controller: {_guidService.Guid}");

        var result = _employeeService.GetAllEmployees();
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetEmployee")]
    public IActionResult GetEmployee(int id)
    {
        var employee = _employeeService.GetEmployee(id);

        if (employee is null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpGet("{id}/Projects")]
    public async Task<IActionResult> GetEmployeeWithProjects(int id)
    {
        var result = await _employeeService.GetEmployeeWithProjects(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewEmployee(Employee newEmployee)
    {
        var employee = await _employeeService.CreateNewEmployee(newEmployee);
        return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.ID }, newEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
    {
        var employee = _employeeService.GetEmployee(id);

        if (employee is null)
        {
            return NotFound();
        }

        await _employeeService.UpdateEmployee(id, updatedEmployee);
        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = _employeeService.GetEmployee(id);

        if (employee is null)
        {
            return NotFound();
        }

        int removedItemsCount = await _employeeService.DeleteEmployee(id);
        return NoContent();
    }
}
