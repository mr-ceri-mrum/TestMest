using Microsoft.EntityFrameworkCore;
using TestMest.Data;
using TestMest.Interfaces;
using TestMest.Models;
using TestMest.Models.ModelViews;

namespace TestMest.Services;

public class CarService : ICarService
{
    private readonly DataContext _context;

    public CarService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCar()
    {
        var result = await _context.Set<Car>()
            .Include(x => x.Color)
            .AsNoTracking()
            .ToListAsync();
        return result;
    }

    public async Task<Car?> UpdateCar( int id,CarView carView)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(x  => x.Id == id);
        
        if (car != null)
        {
            car.BrandName = carView.BrandName ?? car.BrandName;
            car.ColorId = carView.ColorId ?? car.ColorId;
            car.ModelName = carView.ModelName ?? car.ModelName;
            
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        return null;
    }

    public async Task<Car> CreateCar(CreatCarView carView)
    {

        var car = new Car(carView.BrandName, carView.ModelName, carView.ColorId);
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
        
        return car;
    }

    public async Task<Car?> DeleteCar(int id)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
        if (car == null)
            return null;
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task<List<Color>> GetAllColors()
    {
        var colors = await _context.Colors.AsNoTracking().ToListAsync();
        return colors;
    }
    
    public async Task<Color> AddColor(string colorName)
    {
        var color = new Color(colorName);
        await _context.Colors.AddAsync(color);

        await _context.SaveChangesAsync();

        return color;
    }
}