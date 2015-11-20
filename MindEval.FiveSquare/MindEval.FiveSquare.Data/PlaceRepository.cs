using System.Collections.Generic;
using System.Linq;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Data
{
    public class PlaceRepository
    {
        private List<DTO.Place> places;
        private static PlaceRepository instance;

        private PlaceRepository()
        {
            places = new List<DTO.Place>();
            //TODO: fillPlaces
        }

        public static PlaceRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlaceRepository();
                return instance;
            }
        }

        public DTO.Place FindUserById(int id)
        {
            DTO.Place place = places.First(p => p.Id == id);
            return place;
        }

        public bool Exist(int id)
        {
            DTO.Place place = places.First(p => p.Id == id);
            return place != null;
        }

        public List<DTO.Place> GetNearbyPlaces(decimal longitude, decimal latitude)
        {
            List<DTO.Place> nearbyPlaces = new List<DTO.Place>();
            nearbyPlaces.AddRange(
                places.OrderBy(x =>
                    ((longitude - x.Longitude) * (longitude - x.Longitude) + (latitude - x.Latitude) * (latitude - x.Latitude))
                ).Take(5));
            return nearbyPlaces;
        }
    }
}