namespace TestMest.Models.Entitys;

public class Color
{
    public Color(string colorName)
    {
        ColorName = colorName;
    }

    public Color() { }
    
    public int Id { get; set; }
    public string ColorName { get; set; }
}