using Microsoft.EntityFrameworkCore;

namespace SeatManagement
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SeatManagementDbContext _context;

        public Repository(SeatManagementDbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T[] GetAll()
        {
            return _context.Set<T>().ToArray();
        }
    }
}
