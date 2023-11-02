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
    public async Task<IActionResult> GetCars()
    {
        var result = await _carService.GetCars();
        return Ok(result);
    }
    
     
    [HttpDelete("DeleteCar")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var result = await _carService.DeleteCar(id);
        if (result == null)
            return BadRequest("Not found car");
        return Ok(result);
    }
    
    [HttpPost("CreateCar")]
    public async Task<IActionResult> CreateCar(CreatCarView carView)
    {
        var result = await _carService.CreateCar(carView);
        return Ok(result);
    }
    
    [HttpPut("updateCar")]
    public async Task<IActionResult> UpdateCar( int id, [FromForm] CarView carView)
    {
        var result = await _carService.UpdateCar(id,carView);
        if (result == null)
            return BadRequest("not found car");
        return Ok(result); 
    }
}