using Microsoft.EntityFrameworkCore;
using SeatManagement.Models;
namespace SeatManagement
{
    public class CabinRoomRepository : ICabinRoomRepository
    {
        private readonly SeatManagementDbContext _context;

        public CabinRoomRepository(SeatManagementDbContext context)
        {
            _context = context;
        }

        public void Add(Seat item)
        {
            _context.Set<Seat>().Add(item);
            _context.SaveChanges();
        }

        public void Update(Seat item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _context.Set<Seat>().Remove(item);
            _context.SaveChanges();
        }

        public Seat GetById(int id)
        {
            return _context.Set<Seat>().Find(id);
        }

        public Seat[] GetAll()
        {
            return _context.Set<Seat>().Include(x => x.Facility).ToArray();
        }
    }
}
