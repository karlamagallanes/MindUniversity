using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindEval.FiveSquare.Business
{
    public interface ICheckManager
    {
        void CheckIn(int id, string token);
        void CheckOut(int id, string token);

        void Rate(int id, int rate, string token);
        decimal Rate(int id, string token);

        int Count(int id, string token);
        void Time(int id, string token);
    }
}
