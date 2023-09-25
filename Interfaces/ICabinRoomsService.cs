// ICabinRoomsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface ICabinRoomsService
{
    IEnumerable<CabinRoom> GetCabinRooms();
    CabinRoom GetCabinRoom(int id);
    void PutCabinRoom(CabinRoom cabinRoom);
    CabinRoom PostCabinRoom(CabinRoomDTO cabinRoomDTO);
    void DeleteCabinRoom(int id);
    IEnumerable<CabinRoom> GetFreeCabinRooms(string cabinNumber, string floorNumber, string cityId, string facilityName);
    void AllocateCabinRoom(CabinRoomDTO cabinRoomDTO, int id);
    void DeallocateCabinRoom(int id);
}
