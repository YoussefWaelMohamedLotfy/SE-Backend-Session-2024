namespace BackendSessionDemo.Domain;

public class CarLicense
{
    public int ID { get; set; }

    public int ValidityInMonths { get; set; }

    public int OwningEmployeeID { get; set; }

    public Employee OwningEmployee { get; set; }
}
