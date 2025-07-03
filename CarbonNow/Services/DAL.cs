using CarbonNow.Data;
using Microsoft.EntityFrameworkCore;

namespace CarbonNow.Services
{
    public class DAL<T> where T : class
    {

        private readonly CarbonNowDbContext _context;

        public DAL(CarbonNowDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> ListAll(string[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
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

        public T? RecuperarPor(Func<T, bool> condicao, string[]? includes = null)
        {

            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                // ...percorre cada string (ex: "TipoTransporte", "Usuario")...
                foreach (var include in includes)
                {
                    // ...e adiciona o .Include() à query do Entity Framework.
                    query = query.Include(include);
                }
            }

            // Executa a query final com os includes e a condição.
            return query.FirstOrDefault(condicao);

        }

    }
}
