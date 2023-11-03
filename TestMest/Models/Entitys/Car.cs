using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TestMest.Models.Enums;

namespace TestMest.Models;

public class Car
{
    public Car(string brandName, string? modelName, int colorId)
    {
        BrandName = brandName;
        ModelName = modelName;
        ColorId = colorId;
    }

    public Car() { }
    
    public int Id { get; set; }
    [ForeignKey(nameof(Color))]
    public int ColorId { get; set; }
    public virtual Color Color { get; set; }
    public string BrandName { get; set; }
    public string? ModelName { get; set; }
    
    public StatusCar StatusCar { get; set; } = StatusCar.InStock;
}