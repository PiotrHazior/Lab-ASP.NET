using Data;
using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public class EFTravelService : ITravelService
    {
        private readonly AppDbContext _context;

        public EFTravelService(AppDbContext context)
        {
            _context = context;
        }

        public void add(Travel travel)
        {
            _context.Travels.Add(TravelMapper.ToEntity(travel));
            _context.SaveChanges();
        }

        public List<Travel> FindAll()
        {
            return _context.Travels.Select(e => TravelMapper.FromEntity(e)).ToList();
        }

        public Travel? FindByID(int id)
        {
            var find = _context.Travels.Find(id);
            return find is not null ? TravelMapper.FromEntity(find) : null;
        }

        public PagingList<Travel> FindPage(int page, int size)
        {
            return PagingList<Travel>.Create(
                (p, s) =>
                    _context.Travels
                    .OrderBy(c => c.Name)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .Select(TravelMapper.FromEntity)
                    .ToList()
                ,
                page,
                size,
                _context.Travels.Count()
                );
        }

        public void RemoveByID(int id)
        {
            var find = _context.Travels.Find(id);
            if (find is not null)
            {
                _context.Travels.Remove(find);
                _context.SaveChanges();
            }

        }

        public void Update(Travel travel)
        {
            var entity = TravelMapper.ToEntity(travel);
            _context.Travels.Update(entity);
            _context.SaveChanges();
        }
    }
}
