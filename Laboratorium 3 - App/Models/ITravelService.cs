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
        PagingList<Travel> FindPage(int page, int size);
    }
}
