// AssetsService.cs
using SeatManagement.DTOs;
using SeatManagement;
using SeatManagement.Models;
using SeatManagement.Interfaces;

public class AssetsService : IAssetsService
{
    private readonly IRepository<Asset> _repository;

    public AssetsService(IRepository<Asset> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Asset> GetAssets()
    {
        return _repository.GetAll();
    }

    public Asset GetAsset(int id)
    {
        var asset = _repository.GetById(id);
        return asset;
    }

    public void PutAsset(Asset asset)
    {
        var item = _repository.GetById(asset.Id);
        if (item == null)
        {
            return;
        }
        item.Name = asset.Name;
        // Add any other properties you need to update
        _repository.Update(item);
    }

    public Asset PostAsset(AssetDTO assetDTO)
    {
        var asset = new Asset
        {
            Name = assetDTO.Name,
            // Add any other properties you need to set
        };
        _repository.Add(asset);
        return asset;
    }

    public void DeleteAsset(int id)
    {
        var asset = _repository.GetById(id);
        if (asset == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}
