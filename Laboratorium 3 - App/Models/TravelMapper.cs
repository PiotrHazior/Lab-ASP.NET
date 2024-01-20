using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public class TravelMapper
    {
        public static Travel FromEntity(TravelEntity entity)
        {
            return new Travel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                StartPlace = entity.StartPlace,
                EndPlace = entity.EndPlace,
                NumbParticipants = entity.NumbParticipants,
                Guide = entity.Guide,
                TravelAgencyId = entity.TravelAgencyId,
            };
        }

        public static TravelEntity ToEntity(Travel model)
        {
            return new TravelEntity()
            {
                Id = model.Id,
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                StartPlace = model.StartPlace,
                EndPlace = model.EndPlace,
                NumbParticipants = model.NumbParticipants,
                Guide = model.Guide,
                TravelAgencyId = model.TravelAgencyId
            };
        }
    }
}
