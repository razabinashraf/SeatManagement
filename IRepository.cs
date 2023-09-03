namespace SeatManagement
{
    public interface IRepository<T> where T : class
    {
        public T[] GetAll();
        public T GetById(int id);
        public void Update(T item);
        public void Delete(int id);
        public void Add(T item);
    }
}