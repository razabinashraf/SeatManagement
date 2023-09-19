// SeatsService.cs
using SeatManagement.Models;
using SeatManagement;
using SeatManagement.DTOs;
using SeatManagement.Exceptions;

public class SeatsService : ISeatsService
{
    private readonly IRepository<Seat> _repository;
    private readonly IRepository<Facility> _facilityRepository;
    private readonly IRepository<Building> _buildingRepository;
    private readonly IRepository<City> _cityRepository;
    private readonly IRepository<Seat> _seatRepository;
    private readonly IRepository<Seat> _cabinRoomRepository;
    private readonly SeatManagementDbContext _context;

    public SeatsService(
        IRepository<Seat> repository,
        IRepository<City> cityRepository,
        IRepository<Seat> seatRepository,
        IRepository<Seat> cabinRoomRepository,
        SeatManagementDbContext context)
    {
        _repository = repository;
        _cityRepository = cityRepository;
        _seatRepository = seatRepository;
        _cabinRoomRepository = cabinRoomRepository;
        _context = context;
    }

    public IEnumerable<Seat> GetSeats()
    {
        return _repository.GetAll();
    }

    public IEnumerable<Seat> GetFreeSeats(string seatNumber, string floorNumber, string cityId, string facilityName)
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
        if (!string.IsNullOrEmpty(facilityName))
        {
            freeSeats = freeSeats.Where(x => x.Facility.Name == facilityName);
        }
        if (!string.IsNullOrEmpty(cityId))
        {
            if (_cityRepository.GetById(Convert.ToInt32(cityId)) == null)
            {
                throw new ExceptionWhileAdding("City Id is invalid");
            }
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
        if(seatDTO == null)
        {
            throw new ExceptionWhileAdding("Details not provided");
        }
        if(_seatRepository.GetAll().Where(x => x.EmployeeId == seatDTO.EmployeeId).Count() > 0)
        {
            throw new ExceptionWhileAdding("Employee is already allocated a seat");
        }

        if (_cabinRoomRepository.GetAll().Where(x => x.EmployeeId == seatDTO.EmployeeId).Count() > 0)
        {
            throw new ExceptionWhileAdding("Employee is already allocated a cabin");
        }
        var seat = _repository.GetAll().FirstOrDefault(x => x.EmployeeId == null && x.SeatNumber == seatDTO.SeatNumber && x.FacilityId == seatDTO.FacilityId);
        if (seat != null)
        {
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
