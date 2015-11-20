using System.Collections.Generic;
using DTO = MindEval.FiveSquare.Common;
namespace MindEval.FiveSquare.Business
{
    public interface IPlace
    {
        List<DTO.Place> GetNearby(decimal latitude, decimal longitude, string token);

    }
}