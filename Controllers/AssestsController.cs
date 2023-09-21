// AssetsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Exceptions;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly IAssetsService _assetsService;

    public AssetsController(IAssetsService assetsService)
    {
        _assetsService = assetsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Asset>> GetAsset()
    {
        return Ok(_assetsService.GetAssets());
    }

    [HttpGet("{id}")]
    public ActionResult<Asset> GetAsset(int id)
    {
        try
        {
            var asset = _assetsService.GetAsset(id);
            return Ok(asset);
        }
        catch(ExceptionWhileFetching ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        

    }

    [HttpPost]
    public ActionResult<Asset> PostAsset(AssetDTO assetDTO)
    {
        var asset = _assetsService.PostAsset(assetDTO);

        return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
    }

}
