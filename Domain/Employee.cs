namespace BackendSessionDemo.Domain;

public class Employee
{
    public int ID { get; set; }

    public string FullName { get; set; }

    public double Salary { get; set; }

    public Department WorkingDepartment { get; set; }

    public CarLicense LicenseOwned { get; set; }

    public List<Project> WorkingProjects { get; set; }
}
