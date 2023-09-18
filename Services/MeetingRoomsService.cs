// MeetingRoomsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class MeetingRoomsService : IMeetingRoomsService
{
    private readonly IRepository<MeetingRoom> _repository;

    public MeetingRoomsService(IRepository<MeetingRoom> repository)
    {
        _repository = repository;
    }

    public IEnumerable<MeetingRoom> GetMeetingRooms()
    {
        return _repository.GetAll();
    }

    public MeetingRoom GetMeetingRoom(int id)
    {
        var meetingRoom = _repository.GetById(id);
        return meetingRoom;
    }

    public void PutMeetingRoom(MeetingRoom meetingRoom)
    {
        var item = _repository.GetById(meetingRoom.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of MeetingRoom as needed
        item.Name = meetingRoom.Name;
        item.FacilityId = meetingRoom.FacilityId;
        item.SeatCount = meetingRoom.SeatCount;
        // Add any other properties you need to update
        _repository.Update(item);
    }

    public MeetingRoom PostMeetingRoom(MeetingRoomDTO meetingRoomDTO)
    {
        var meetingRoom = new MeetingRoom
        {
            Name = meetingRoomDTO.Name,
            FacilityId = meetingRoomDTO.FacilityId,
            SeatCount = meetingRoomDTO.SeatCount,
            // Add any other properties you need to set
        };
        _repository.Add(meetingRoom);
        return meetingRoom;
    }

    public void DeleteMeetingRoom(int id)
    {
        var meetingRoom = _repository.GetById(id);
        if (meetingRoom == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}
