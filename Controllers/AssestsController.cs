// AssetsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
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
        var asset = _assetsService.GetAsset(id);

        if (asset == null)
        {
            return NotFound();
        }

        return asset;
    }

    [HttpPut("{id}")]
    public IActionResult PutAsset(Asset asset)
    {
        _assetsService.PutAsset(asset);
        return Ok();
    }

    [HttpPost]
    public ActionResult<Asset> PostAsset(AssetDTO assetDTO)
    {
        var asset = _assetsService.PostAsset(assetDTO);

        return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAsset(int id)
    {
        _assetsService.DeleteAsset(id);
        return NoContent();
    }
}
