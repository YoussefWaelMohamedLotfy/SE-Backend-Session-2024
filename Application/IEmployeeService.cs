using BackendSessionDemo.Domain;

namespace Application;
public interface IEmployeeService
{
    Task<Employee> CreateNewEmployee(Employee newEmployee);
    Task<int> DeleteEmployee(int id);
    List<Employee> GetAllEmployees();
    Employee? GetEmployee(int id);
    Task<Employee?> GetEmployeeWithProjects(int id);
    Task<Employee?> UpdateEmployee(int id, Employee updatedEmployee);
}