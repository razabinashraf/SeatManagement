// AllocatedAssetsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class AllocatedAssetsService : IAllocatedAssetsService
{
    private readonly IRepository<AllocatedAsset> _repository;

    public AllocatedAssetsService(IRepository<AllocatedAsset> repository)
    {
        _repository = repository;
    }

    public IEnumerable<AllocatedAsset> GetAllocatedAssets()
    {
        return _repository.GetAll();
    }

    public AllocatedAsset GetAllocatedAsset(int id)
    {
        var allocatedAsset = _repository.GetById(id);
        return allocatedAsset;
    }

    public void PutAllocatedAsset(AllocatedAsset allocatedAsset)
    {
        var item = _repository.GetById(allocatedAsset.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of AllocatedAsset as needed
        item.MeetingRoomId = allocatedAsset.MeetingRoomId;
        item.Quantity = allocatedAsset.Quantity;
        item.AssetId = allocatedAsset.AssetId;
        _repository.Update(item);
    }

    public AllocatedAsset PostAllocatedAsset(AllocatedAssetDTO allocatedAssetDTO)
    {
        var allocatedAsset = new AllocatedAsset
        {
            AssetId = allocatedAssetDTO.AssetId,
            MeetingRoomId = allocatedAssetDTO.MeetingRoomId,
            Quantity = allocatedAssetDTO.Quantity,
        };
        _repository.Add(allocatedAsset);
        return allocatedAsset;
    }

    public void DeleteAllocatedAsset(int id)
    {
        var allocatedAsset = _repository.GetById(id);
        if (allocatedAsset == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}