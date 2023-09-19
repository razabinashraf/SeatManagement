using Microsoft.EntityFrameworkCore;
using SeatManagement.Models;

namespace SeatManagement
{
    public interface ICabinRoomRepository
    {
        public void Add(CabinRoom item);

        public void Update(CabinRoom item);

        public void Delete(int id);

        public CabinRoom GetById(int id);

        public CabinRoom[] GetAll();
    }
}
