using System.Security.Claims;
using TestMest.Models;
using TestMest.Models.ModelViews;

namespace TestMest.Interfaces;

public interface ICarService
{
    Task<List<Car>> GetCar();
    Task<List<Color>> GetAllColors();
    Task<Car?> DeleteCar(int id);
    Task<Car>CreateCar(CreatCarView carView);
    Task<Car?> UpdateCar(int id,CarView carView);
    Task<Color> AddColor(string colorName);
}