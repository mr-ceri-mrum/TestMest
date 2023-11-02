using System.Security.Claims;
using TestMest.Models;
using TestMest.Models.ModelViews;

namespace TestMest.Interfaces;

public interface ICarService
{
    Task<List<Car>> GetCars();
    Task<Car?> DeleteCar(int id);
    Task<Car>CreateCar(CreatCarView carView);
    Task<Car?> UpdateCar(int id,CarView carView);
}