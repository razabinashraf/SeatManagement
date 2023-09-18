﻿// SeatsService.cs
using SeatManagement.Models;
using SeatManagement;

public class SeatsService : ISeatsService
{
    private readonly IRepository<Seat> _repository;

    public SeatsService(IRepository<Seat> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Seat> GetSeats()
    {
        return _repository.GetAll();
    }

    public IEnumerable<Seat> GetFreeSeats(string seatNumber, string floorNumber, string cityId)
    {
        var freeSeats = _repository.GetAll().Where(x => x.EmployeeId == null);

        if (!string.IsNullOrEmpty(seatNumber))
        {
            freeSeats = freeSeats.Where(x => x.SeatNumber == Convert.ToInt32(seatNumber));
        }
        if (!string.IsNullOrEmpty(floorNumber))
        {
            freeSeats = freeSeats.Where(x => x.Facility.FloorNumber == Convert.ToInt32(floorNumber));
        }
        if (!string.IsNullOrEmpty(cityId))
        {
            freeSeats = freeSeats.Where(x => x.Facility.CityId == Convert.ToInt32(cityId));
        }

        return freeSeats.ToList();
    }

    public Seat GetSeat(int id)
    {
        return _repository.GetById(id);
    }

    public void AllocateSeat(SeatDTO seatDTO)
    {
        var seat = _repository.GetAll().FirstOrDefault(x => x.EmployeeId == null && x.SeatNumber == seatDTO.SeatNumber && x.FacilityId == seatDTO.FacilityId);
        if (seat != null)
        {
            // Allocate the seat
            seat.EmployeeId = seatDTO.EmployeeId;
            _repository.Update(seat);
        }
    }

    public void DeallocateSeat(int id, Seat seat)
    {
        var existingSeat = _repository.GetById(id);
        if (existingSeat != null)
        {
            // Deallocate the seat
            existingSeat.EmployeeId = null;
            _repository.Update(existingSeat);
        }
    }

    public void PostSeats(SeatDTO[] seatDTOs)
    {
        foreach (var seatDTO in seatDTOs)
        {
            var seat = new Seat
            {
                SeatNumber = seatDTO.SeatNumber,
                EmployeeId = null,
                FacilityId = seatDTO.FacilityId
                // Add any other properties you need to set
            };
            _repository.Add(seat);
        }
    }

    public void DeleteSeat(int id)
    {
        var seat = _repository.GetById(id);
        if (seat != null)
        {
            _repository.Delete(id);
        }
    }
}