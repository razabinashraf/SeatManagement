// IAllocatedAssetsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IAllocatedAssetsService
{
    IEnumerable<AllocatedAsset> GetAllocatedAssets();
    AllocatedAsset GetAllocatedAsset(int id);
    void PutAllocatedAsset(AllocatedAsset allocatedAsset);
    AllocatedAsset PostAllocatedAsset(AllocatedAssetDTO allocatedAssetDTO);
    void DeleteAllocatedAsset(int id);
}
