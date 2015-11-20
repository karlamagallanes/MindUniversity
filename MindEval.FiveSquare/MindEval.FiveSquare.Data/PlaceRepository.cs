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
            var place = from u in places
                       where u.Id == id
                       select u;
            return (DTO.Place)place;
        }

        public bool Exist(int id)
        {
            var place = from p in places
                        where p.Id == id
                       select p;
            return place != null;
        }

    }
}