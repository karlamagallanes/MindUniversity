using System;
using System.Collections.Generic;
using System.Linq;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Data
{
    public class CheckRepository
    {
        private Dictionary<int, int> checkInCount;
        private List<Tuple<int, int>> placeRate;

        private static CheckRepository instance;

        private CheckRepository()
        {
        }

        public static CheckRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new CheckRepository();
                return instance;
            }
        }

        public void CheckIn(int id)
        {
            int count;
            if (checkInCount.TryGetValue(id, out count))
                checkInCount[id]++;
            else
                checkInCount.Add(id, 1);
        }

        public void CheckOut(int id)
        {
            int count;
            if (checkInCount.TryGetValue(id, out count))
                checkInCount[id]--;
        }

        public int Count(int id)
        {
            int count = 0;
            checkInCount.TryGetValue(id, out count);
            return count;
        }

        public void Rate(int id, int rate)
        {
            placeRate.Add(new Tuple<int, int>(id, rate));
        }

        public decimal Rate(int id)
        {
            decimal totalRate = 0;
            decimal count = 0;

            List<Tuple<int, int>> ratings = (List<Tuple<int, int>>)placeRate.Where(p => p.Item1 == id);
            foreach (Tuple<int, int> rate in ratings)
            {
                totalRate += rate.Item2;
                count++;
            }
            if (count == 0)
                throw new DTO.MamalonaException(DTO.MamalonaMessage.PlaceWithoutRatings);

            return totalRate / count;
        }
    }
}