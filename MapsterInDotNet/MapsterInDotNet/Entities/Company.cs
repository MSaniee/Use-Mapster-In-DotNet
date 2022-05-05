namespace MapsterInDotNet.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}

