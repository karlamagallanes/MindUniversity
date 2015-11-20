using System.Collections.Generic;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Business
{
    public class Place : IPlace
    {
        private Data.PlaceRepository _placeRepository;
        private AccountService _accountService;

        public Place()
        {
            _placeRepository = Data.PlaceRepository.Instance;
            _accountService = new AccountService();
        }

        public List<DTO.Place> GetNearby(decimal longitude, decimal latitude, string token)
        {
            _accountService.ValidateActiveToken(token);
            return _placeRepository.GetNearbyPlaces(longitude, latitude);
        }
    }
}