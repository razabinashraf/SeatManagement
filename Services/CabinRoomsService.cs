// CabinRoomsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class CabinRoomsService : ICabinRoomsService
{
    private readonly IRepository<CabinRoom> _repository;

    public CabinRoomsService(IRepository<CabinRoom> repository)
    {
        _repository = repository;
    }

    public IEnumerable<CabinRoom> GetCabinRooms()
    {
        return _repository.GetAll();
    }

    public CabinRoom GetCabinRoom(int id)
    {
        var cabinRoom = _repository.GetById(id);
        return cabinRoom;
    }

    public void PutCabinRoom(CabinRoom cabinRoom)
    {
        var item = _repository.GetById(cabinRoom.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of CabinRoom as needed
        item.Name = cabinRoom.Name;
        item.EmployeeId = cabinRoom.EmployeeId;
        item.FacilityId = cabinRoom.FacilityId;
        // Add any other properties you need to update
        _repository.Update(item);
    }

    public CabinRoom PostCabinRoom(CabinRoomDTO cabinRoomDTO)
    {
        var cabinRoom = new CabinRoom
        {
            Name = cabinRoomDTO.Name,
            FacilityId = cabinRoomDTO.FacilityId,
            EmployeeId = cabinRoomDTO.EmployeeId
            // Add any other properties you need to set
        };
        _repository.Add(cabinRoom);
        return cabinRoom;
    }

    public void DeleteCabinRoom(int id)
    {
        var cabinRoom = _repository.GetById(id);
        if (cabinRoom == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}
