using System.Security.Claims;
using TestMest.Models;
using TestMest.Models.ActionResult;
using TestMest.Models.Views;

namespace TestMest.Interfaces;

public interface ICarService
{
    Task<ActionMethodResult> GetCars();
    Task<ActionMethodResult> DeleteCar(int id);
    Task<ActionMethodResult> CreateCar(CreatCarView carView);
    Task<ActionMethodResult> UpdateCar(int id,CarView carView);
    Task<ActionMethodResult> BuyCar(int id);
}