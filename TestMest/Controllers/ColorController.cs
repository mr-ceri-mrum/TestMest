using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMest.Interfaces;

namespace TestMest.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ColorController : ControllerBase
{
    private readonly IColorService _colorService;

    public ColorController(IColorService colorService)
    {
        _colorService = colorService;
    }
    
    [HttpGet("GetColors")]
    public async Task<IActionResult> GetAllColors()
    {
        var result = _colorService.GetAllColors();
        return Ok(result);
    }
    
    [HttpPost("AddColor")]
    public async Task<IActionResult> AddColor(string color)
    {
        var result = await _colorService.AddColor(color);
        return Ok(result);
    }
}