namespace BackendSessionDemo.Domain;

public class Project
{
    public int ID { get; set; }

    public string ProjectName { get; set; }

    public int DurationInMonths { get; set; }

    public List<Employee> WorkingEmployees { get; set; }
}
