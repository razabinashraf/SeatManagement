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

        public void Add(CabinRoom item)
        {
            _context.Set<CabinRoom>().Add(item);
            _context.SaveChanges();
        }

        public void Update(CabinRoom item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _context.Set<CabinRoom>().Remove(item);
            _context.SaveChanges();
        }

        public CabinRoom GetById(int id)
        {
            return _context.Set<CabinRoom>().Find(id);
        }

        public CabinRoom[] GetAll()
        {
            return _context.Set<CabinRoom>().Include(x => x.Facility).ToArray();
        }
    }
}
