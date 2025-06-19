using CarbonNow.Data;

namespace CarbonNow.Services
{
    public class DAL<T> where T : class
    {

        private readonly CarbonNowDbContext _context;

        public DAL(CarbonNowDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> ListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T objeto)
        {
            _context.Set<T>().Add(objeto);
            _context.SaveChanges();
        }

        public void Delete(T objeto)
        {
            _context.Set<T>().Remove(objeto);
            _context.SaveChanges();
        }

        public void Update(T objeto)
        {
            _context.Set<T>().Update(objeto);
            _context.SaveChanges();
        }

    }
}
