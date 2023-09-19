using Microsoft.EntityFrameworkCore;
using SeatManagement.Models;

namespace SeatManagement
{
    public interface ISeatRepository
    {
        public void Add(Seat item);

        public void Update(Seat item);

        public void Delete(int id);

        public Seat GetById(int id);

        public Seat[] GetAll();
    }
}
