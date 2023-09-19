// CabinRoomsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;
using SeatManagement.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class CabinRoomsService : ICabinRoomsService
{
    //private readonly IRepository<CabinRoom> _repository;
    private readonly ICabinRoomRepository _repository;

    private readonly IRepository<Seat> _seatRepository;
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Facility> _facilityRepository;
    private readonly IRepository<City> _cityRepository;

    private readonly SeatManagementDbContext _context;

    public CabinRoomsService(
        //IRepository<CabinRoom> repository,
        ICabinRoomRepository repository,

        IRepository<Seat> seatRepository,
        IRepository<Employee> employeeRepository,
        IRepository<Facility> facilityRepository,
        IRepository<City> cityRepository,
        SeatManagementDbContext context
        )
    {
        _repository = repository;
        _seatRepository = seatRepository;
        _employeeRepository = employeeRepository;
        _facilityRepository = facilityRepository;
        _cityRepository = cityRepository;
        _context = context;
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
            throw new ExceptionWhileAdding("Cabin room does not exist");
        }
        if(_employeeRepository.GetById((int)cabinRoom.EmployeeId) == null)
        {
            throw new ExceptionWhileAdding("Employee id is invalid");
        }
        if (_employeeRepository.GetById((int)cabinRoom.EmployeeId) == null)
        {
            throw new ExceptionWhileAdding("Employee id is invalid");
        }
        item.Name = cabinRoom.Name;
        item.EmployeeId = cabinRoom.EmployeeId;
        item.FacilityId = cabinRoom.FacilityId;
        _repository.Update(item);
    }

    public CabinRoom PostCabinRoom(CabinRoomDTO cabinRoomDTO)
    {
        var cabinRoom = new CabinRoom
        {
            Name = cabinRoomDTO.Name,
            Number = cabinRoomDTO.Number,
            FacilityId = cabinRoomDTO.FacilityId,
            EmployeeId = cabinRoomDTO.EmployeeId
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

    public IEnumerable<CabinRoom> GetFreeCabinRooms(string cabinNumber, string floorNumber, string cityId, string facilityName)
    {
        var freeCabinRooms = _repository.GetAll().Where(x => x.EmployeeId == null);
        //var freeCabinRooms = _context.CabinRooms.Where(x => x.EmployeeId == null).Include(x => x.Facility).ToList();

        if (!string.IsNullOrEmpty(cabinNumber))
        {
            freeCabinRooms = freeCabinRooms.Where(x => x.Number == cabinNumber).ToList();
        }
        if (!string.IsNullOrEmpty(floorNumber))
        {
            freeCabinRooms = freeCabinRooms.Where(x => x.Facility.FloorNumber == Convert.ToInt32(floorNumber)).ToList();
        }
        if (!string.IsNullOrEmpty(facilityName))
        {
            freeCabinRooms = freeCabinRooms.Where(x => x.Facility.Name == facilityName).ToList();
        }
        if (!string.IsNullOrEmpty(cityId))
        {
            if (_cityRepository.GetById(Convert.ToInt32(cityId)) == null)
            {
                throw new ExceptionWhileAdding("City Id is invalid");
            }
            freeCabinRooms = freeCabinRooms.Where(x => x.Facility.CityId == Convert.ToInt32(cityId)).ToList();
        }

        return freeCabinRooms.ToList();
    }

    public void AllocateCabinRoom(CabinRoomDTO cabinRoomDTO)
    {
        if (cabinRoomDTO == null)
        {
            throw new ExceptionWhileAdding("Details not provided");
        }
        if (_seatRepository.GetAll().Where(x => x.EmployeeId == cabinRoomDTO.EmployeeId).Count() > 0)
        {
            throw new ExceptionWhileAdding("Employee is already allocated a seat");
        }

        if (_repository.GetAll().Where(x => x.EmployeeId == cabinRoomDTO.EmployeeId).Count() > 0)
        {
            throw new ExceptionWhileAdding("Employee is already allocated a cabin");
        }
        var cabinRoom = _repository.GetAll().FirstOrDefault(x => x.EmployeeId == null && x.FacilityId == cabinRoomDTO.FacilityId);
        if (cabinRoom != null)
        {
            cabinRoom.EmployeeId = cabinRoomDTO.EmployeeId;
            _repository.Update(cabinRoom);
        }
    }

    public void DeallocateCabinRoom(int id, CabinRoomDTO cabinRoomDTO)
    {
        var existingCabinRoom = _repository.GetById(id);
        if (existingCabinRoom == null)
        {
            throw new ExceptionWhileUpdating("Cabin room id does not exist");
        }
    }

}
