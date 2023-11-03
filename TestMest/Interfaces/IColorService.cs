using TestMest.Models;
using TestMest.Models.ActionResult;

namespace TestMest.Interfaces;

public interface IColorService
{
    Task<ActionMethodResult> AddColor(string colorName);
    Task<ActionMethodResult> GetAllColors();
}