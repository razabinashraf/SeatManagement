// ISeatsService.cs
using SeatManagement.Models;

public interface ISeatsService
{
    IEnumerable<Seat> GetSeats();
    IEnumerable<Seat> GetFreeSeats(string seatNumber, string floorNumber, string cityId);
    Seat GetSeat(int id);
    void AllocateSeat(SeatDTO seatDTO);
    void DeallocateSeat(int id, Seat seat);
    void PostSeats(SeatDTO[] seatDTOs);
    void DeleteSeat(int id);
}
