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
}
