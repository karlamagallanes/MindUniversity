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
            places = new List<DTO.Place> {
                new DTO.Place {  Id=1, Name= "Mind", Description="Empresa de software", Latitude=(decimal)32.522214, Longitude=(decimal)-117.019112},
                new DTO.Place {  Id=2, Name= "Sospeso",  Description="Cafe", Latitude=(decimal)32.522865, Longitude=(decimal)-117.017599},
                new DTO.Place {  Id=3, Name= "Sazon Casero", Description="Comida", Latitude=(decimal)32.520900, Longitude=(decimal)-117.018272},
                new DTO.Place {  Id=4, Name= "Cecut", Description="Centro Cultural Tijuana" ,Latitude=(decimal)32.530552, Longitude=(decimal)-117.023320},
                new DTO.Place {  Id=5, Name= "Lugar del Nopal", Description="Canta bar", Latitude=(decimal)32.529378, Longitude=(decimal)-117.044498},
                new DTO.Place {  Id=6, Name= "Garita de Otay", Description="Garita Internacional de Otay",  Latitude=(decimal)32.550577, Longitude=(decimal)-116.938389},
                new DTO.Place {  Id=7, Name= "Coronado Brewing Company", Description="cerveceria",  Latitude=(decimal)32.697735, Longitude=(decimal)-117.173123}
            };
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