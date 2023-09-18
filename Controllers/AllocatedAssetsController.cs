// AllocatedAssetsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class AllocatedAssetsController : ControllerBase
{
    private readonly IAllocatedAssetsService _allocatedAssetsService;

    public AllocatedAssetsController(IAllocatedAssetsService allocatedAssetsService)
    {
        _allocatedAssetsService = allocatedAssetsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AllocatedAsset>> GetAllocatedAsset()
    {
        return Ok(_allocatedAssetsService.GetAllocatedAssets());
    }

    [HttpGet("{id}")]
    public ActionResult<AllocatedAsset> GetAllocatedAsset(int id)
    {
        var allocatedAsset = _allocatedAssetsService.GetAllocatedAsset(id);

        if (allocatedAsset == null)
        {
            return NotFound();
        }

        return allocatedAsset;
    }

    [HttpPut("{id}")]
    public IActionResult PutAllocatedAsset(AllocatedAsset allocatedAsset)
    {
        _allocatedAssetsService.PutAllocatedAsset(allocatedAsset);
        return Ok();
    }

    [HttpPost]
    public ActionResult<AllocatedAsset> PostAllocatedAsset(AllocatedAssetDTO allocatedAssetDTO)
    {
        var allocatedAsset = _allocatedAssetsService.PostAllocatedAsset(allocatedAssetDTO);

        return CreatedAtAction("GetAllocatedAsset", new { id = allocatedAsset.Id }, allocatedAsset);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAllocatedAsset(int id)
    {
        _allocatedAssetsService.DeleteAllocatedAsset(id);
        return NoContent();
    }
}
