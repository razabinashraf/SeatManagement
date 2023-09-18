// IAssetsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IAssetsService
{
    IEnumerable<Asset> GetAssets();
    Asset GetAsset(int id);
    void PutAsset(Asset asset);
    Asset PostAsset(AssetDTO assetDTO);
    void DeleteAsset(int id);
}
