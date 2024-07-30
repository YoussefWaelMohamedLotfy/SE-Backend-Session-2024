namespace BackendSessionDemo.Domain;

public class Department
{
    public int ID { get; set; }

    public string DepartmentName { get; set; }

    public List<Employee> WorkingEmployees { get; set; }
}
