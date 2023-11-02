using TestMest.Models;

namespace TestMest.Interfaces;

public interface IColorService
{
    Task<Color> AddColor(string colorName);
    IQueryable<Color> GetAllColors();
}