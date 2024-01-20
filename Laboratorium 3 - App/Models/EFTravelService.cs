using Data;
using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public class EFTravelService : ITravelService
    {
        private readonly AppDbContext _travel;

        public EFTravelService(AppDbContext context)
        {
            _travel = context;
        }

        public void add(Travel travel)
        {
            _travel.Travels.Add(TravelMapper.ToEntity(travel));
            _travel.SaveChanges();
        }

        public List<Travel> FindAll()
        {
            return _travel.Travels.Select(e => TravelMapper.FromEntity(e)).ToList();
        }

        public List<TravelAgencyEntity> FindAllTravelAgency()
        {
            return _travel.TravelAgencies.ToList();
        }

        public Travel? FindByID(int id)
        {
            var find = _travel.Travels.Find(id);
            return find is not null ? TravelMapper.FromEntity(find) : null;
        }

        public PagingList<Travel> FindPage(int page, int size)
        {
            return PagingList<Travel>.Create(
                (p, s) =>
                    _travel.Travels
                    .OrderBy(c => c.Name)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .Select(TravelMapper.FromEntity)
                    .ToList()
                ,
                page,
                size,
                _travel.Travels.Count()
                );
        }

        public void RemoveByID(int id)
        {
            var find = _travel.Travels.Find(id);
            if (find is not null)
            {
                _travel.Travels.Remove(find);
                _travel.SaveChanges();
            }

        }

        public void Update(Travel travel)
        {
            var entity = TravelMapper.ToEntity(travel);
            _travel.Travels.Update(entity);
            _travel.SaveChanges();
        }
    }
}
