using Microsoft.EntityFrameworkCore;
using TestMest.Data;
using TestMest.Interfaces;
using TestMest.Models.ActionResult;
using Color = TestMest.Models.Entitys.Color;

namespace TestMest.Services;

public class ColorService : IColorService
{
    private readonly DataContext _context;

    public ColorService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ActionMethodResult> AddColor(string colorName)
    {
        try
        {
            var color = new Color(colorName);
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            
            return ActionMethodResult.Success(color);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<ActionMethodResult> GetAllColors()
    {
        try
        {
            var colors = _context.Colors.AsNoTracking().AsQueryable();
            return ActionMethodResult.Success(colors);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}