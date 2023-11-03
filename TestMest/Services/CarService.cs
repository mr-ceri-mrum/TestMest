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
    
    public async Task<IQueryable<Car>> GetCars()
    {
        try
        {
            var result = _context.Set<Car>()
                .Include(x => x.Color)
                .AsNoTracking();
            
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Car?> UpdateCar( int id,CarView carView)
    {
        try
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x  => x.Id == id);
            if (car == null) return null;
            
            car.BrandName = carView.BrandName ?? car.BrandName;
            car.ColorId = carView.ColorId ?? car.ColorId;
            car.ModelName = carView.ModelName ?? car.ModelName;
            
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Car> CreateCar(CreatCarView carView)
    {
        try
        {
            var car = new Car(carView.BrandName, carView.ModelName, carView.ColorId);
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        
            return car;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Car?> DeleteCar(int id)
    {
        try
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
                return null;
            _context.Cars.Remove(car);
            
            await _context.SaveChangesAsync();
            return car;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Color>> GetAllColors()
    {
        try
        {
            var colors = await _context.Colors.AsNoTracking().ToListAsync();
            return colors;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Color> AddColor(string colorName)
    {
        try
        {
            var color = new Color(colorName);
            
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();

            return color;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}