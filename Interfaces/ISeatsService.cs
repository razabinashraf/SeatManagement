// ISeatsService.cs
using SeatManagement.Models;

public interface ISeatsService
{
    IEnumerable<Seat> GetSeats();
    IEnumerable<Seat> GetFreeSeats(string seatNumber, string floorNumber, string cityId, string facilityName);
    Seat GetSeat(int id);
    void AllocateSeat(SeatDTO seatDTO, int seatId);
    void DeallocateSeat(int id);
    void PostSeats(SeatDTO[] seatDTOs);
    void DeleteSeat(int id);
}
