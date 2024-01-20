using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public interface ITravelService
    {
        void add(Travel travel);
        void RemoveByID(int id);
        void Update(Travel travel);
        List<Travel> FindAll();
        Travel? FindByID(int id);
        List<TravelAgencyEntity> FindAllTravelAgency();
        //PagingList<Travel> FindPage(int page, int size);
    }
}
