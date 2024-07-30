using BackendSessionDemo.Data;
using BackendSessionDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _dbContext;

    public EmployeeService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Employee> GetAllEmployees()
    {
        var result = _dbContext.Employees.ToList();
        return result;
    }

    public Employee? GetEmployee(int id)
    {
        var result = _dbContext.Employees.Find(id);
        return result;
    }

    public async Task<Employee?> GetEmployeeWithProjects(int id)
    {
        var result = await _dbContext.Employees
            .Include(x => x.WorkingProjects)
            .FirstOrDefaultAsync(x => x.ID == id);

        return result;
    }

    public async Task<Employee> CreateNewEmployee(Employee newEmployee)
    {
        await _dbContext.Employees.AddAsync(newEmployee);
        int changesCount = await _dbContext.SaveChangesAsync();
        return newEmployee;
    }

    public async Task<Employee?> UpdateEmployee(int id, Employee updatedEmployee)
    {
        var employee = _dbContext.Employees.Find(id);

        if (employee is null)
        {
            return null;
        }

        Employee newUpdatedEmployee = new()
        {
            ID = employee.ID,
            FullName = updatedEmployee.FullName,
            Salary = updatedEmployee.Salary
        };

        _dbContext.Employees.Update(newUpdatedEmployee);
        await _dbContext.SaveChangesAsync();
        return updatedEmployee;
    }

    public async Task<int> DeleteEmployee(int id)
    {
        var employee = _dbContext.Employees.Find(id);

        if (employee is null)
        {
            return 0;
        }

        _dbContext.Employees.Remove(employee);
        int removedItemsCount = await _dbContext.SaveChangesAsync();
        return removedItemsCount;
    }
}
