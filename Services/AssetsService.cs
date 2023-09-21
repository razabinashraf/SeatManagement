// AssetsService.cs
using SeatManagement.DTOs;
using SeatManagement;
using SeatManagement.Models;
using SeatManagement.Interfaces;
using SeatManagement.Exceptions;

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
        if(asset == null)
        {
            throw new ExceptionWhileFetching("Asset id is invalid");
        }
        return asset;
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

}
