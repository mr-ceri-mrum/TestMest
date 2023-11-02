using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMest.Interfaces;
using TestMest.Models.ModelViews;

namespace TestMest.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet("GetCar")]
    public async Task<ActionResult> GetCar()
    {
        var result = await _carService.GetCar();
        return Ok(result);
    }
    
    [HttpGet("GetColors")]
    public async Task<ActionResult> GetAllColors()
    {
        var result = await _carService.GetAllColors();
        return Ok(result);
    }
     
    [HttpDelete("DeleteCar")]
    public async Task<ActionResult> DeleteCar(int id)
    {
        var result = await _carService.DeleteCar(id);
        if (result == null)
            return BadRequest("Not found car");
        return Ok(result);
    }
    
    [HttpPost("CreateCar")]
    public async Task<ActionResult> CreateCar(CreatCarView carView)
    {
        var result = await _carService.CreateCar(carView);
        return Ok(result);
    }
    
    [HttpPut("updateCar")]
    public async Task<ActionResult> UpdateCar( int id, [FromForm] CarView carView)
    {
        var result = await _carService.UpdateCar(id,carView);
        if (result == null)
            return BadRequest("not found car");
        return Ok(result); 
    }

    [HttpPost("AddColor")]
    public async Task<ActionResult> AddColor(string color)
    {
        var result = await _carService.AddColor(color);
        return Ok(result);
    }
}