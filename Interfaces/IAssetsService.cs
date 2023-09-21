// IAssetsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IAssetsService
{
    IEnumerable<Asset> GetAssets();
    Asset GetAsset(int id);
    Asset PostAsset(AssetDTO assetDTO);
}
