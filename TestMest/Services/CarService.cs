using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestMest.Data;
using TestMest.Helper;
using TestMest.Interfaces;
using TestMest.Models;
using TestMest.Models.ActionResult;
using TestMest.Models.Entitys;
using TestMest.Models.Enums;
using TestMest.Models.Views;

namespace TestMest.Services;

public class CarService : ICarService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CarService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ActionMethodResult> GetCars()
    {
        try
        {
            var result = _context.Set<Car>()
                .Where(x => x.StatusCar == StatusCar.InStock)
                .AsNoTracking()
                .AsQueryable();
            
            return ActionMethodResult.Success(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ActionMethodResult> UpdateCar( int id,CarView carView)
    {
        try
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x  => x.Id == id);
            if (car == null) 
                return ActionMethodResult.Error(MessageHelper.NotFound());
            
            car.BrandName = carView.BrandName ?? car.BrandName;
            car.ColorId = carView.ColorId ?? car.ColorId;
            car.ModelName = carView.ModelName ?? car.ModelName;
            
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Car, CarView>(car);
            
            return ActionMethodResult.Success(result);            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ActionMethodResult> CreateCar(CreatCarView carView)
    {
        try
        {
            var car = new Car(carView.BrandName, carView.ModelName, carView.ColorId);
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        
            return ActionMethodResult.Success(car);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ActionMethodResult> DeleteCar(int id)
    {
        try
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
                return ActionMethodResult.Error(MessageHelper.NotFound());
            _context.Cars.Remove(car);
            
            await _context.SaveChangesAsync();
            return ActionMethodResult.Success(MessageHelper.DeleteSuccess());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<ActionMethodResult> BuyCar(int id)
    {
        try
        {
            var car = await _context.Cars.Include(x => x.Color).FirstOrDefaultAsync(x => x.Id == id);
            if (car == null) 
                return ActionMethodResult.Error(MessageHelper.NotFound());
            
            car.StatusCar = StatusCar.NotAvailable;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            
            var result = _mapper.Map<Car, CarView>(car);
            
            return ActionMethodResult.Success(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ActionMethodResult> GetCarById(int id)
    {
        try
        {
            var car =  await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
                return ActionMethodResult.Error(MessageHelper.NotFound());
            var result = _mapper.Map<Car, CarView>(car);
            
            return ActionMethodResult.Success(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}