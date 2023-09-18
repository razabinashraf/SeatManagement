// IMeetingRoomsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IMeetingRoomsService
{
    IEnumerable<MeetingRoom> GetMeetingRooms();
    MeetingRoom GetMeetingRoom(int id);
    void PutMeetingRoom(MeetingRoom meetingRoom);
    MeetingRoom PostMeetingRoom(MeetingRoomDTO meetingRoomDTO);
    void DeleteMeetingRoom(int id);
}
