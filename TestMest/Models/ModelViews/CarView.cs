namespace TestMest.Models.ModelViews;

public class CarView
{
    public int? ColorId { get; set; }
    public string? BrandName { get; set; } 
    public string? ModelName { get; set; }
}

public class CreatCarView
{
    public int ColorId { get; set; }
    public string BrandName { get; set; } 
    public string ModelName { get; set; }
}