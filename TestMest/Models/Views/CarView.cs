using TestMest.Models.Enums;

namespace TestMest.Models.Views; 

public class CarView
{
    public int? ColorId { get; set; }
    public string? BrandName { get; set; } 
    public string? ModelName { get; set; }
    public StatusCar StatusCar { get; set; }
}

public class CreatCarView
{
    public int ColorId { get; set; }
    public string BrandName { get; set; } 
    public string ModelName { get; set; }
}