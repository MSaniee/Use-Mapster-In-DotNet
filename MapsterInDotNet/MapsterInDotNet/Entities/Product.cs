namespace MapsterInDotNet.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    

    
    public int Weight { get; set; }
    public string Size { get; set; }


    public int ColorId { get; set; }
    public Color Color { get; set; }
}

