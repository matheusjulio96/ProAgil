using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Repository.Data;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }

        //GERAIS         
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }
        
        //EVENTO
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

                if (includePalestrantes){
                    query = query.Include(p => p.PalestranteEventos)
                        .ThenInclude(p => p.Palestrante);
                }

                query = query.OrderByDescending(c => c.DataEvento);

                return await query.ToArrayAsync();
        }

        public Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }


        //PALESTRANTE
        public Task<Evento[]> GetAllPalestrantesAsyncByName(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetPalestranteAsync(int PalestranteId, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }


    }
}