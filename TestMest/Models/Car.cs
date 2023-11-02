using Microsoft.EntityFrameworkCore;

namespace TestMest.Models;

public class Car
{
    public Car(string brandName, string? modelName, int colorId)
    {
        BrandName = brandName;
        ModelName = modelName;
        ColorId = colorId;
    }

    public Car()
    {
        
    }


    public int Id { get; set; }
    public int ColorId { get; set; }
    public virtual Color Color { get; set; }
    public string BrandName { get; set; }
    public string? ModelName { get; set; }
    
}