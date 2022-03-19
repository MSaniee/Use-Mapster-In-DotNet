namespace MapsterInDotNet.Entities;

public class Color
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; }
}

