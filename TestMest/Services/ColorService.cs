using Microsoft.EntityFrameworkCore;
using TestMest.Data;
using TestMest.Interfaces;
using Color = TestMest.Models.Color;

namespace TestMest.Services;

public class ColorService : IColorService
{
    private readonly DataContext _context;

    public ColorService(DataContext context)
    {
        _context = context;
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
    
    public IQueryable<Color> GetAllColors()
    {
        try
        {
            var colors = _context.Colors.AsNoTracking().AsQueryable();
            return colors;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}