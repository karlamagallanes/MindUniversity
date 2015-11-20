using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindEval.FiveSquare.Data
{
    public class ActiveToken
    {
        private List<string> activeTokens;
        private static ActiveToken instance;

        private ActiveToken()
        {
            activeTokens = new List<string>();
        }

        public static ActiveToken Instance
        {
            get
            {
                if (instance == null)
                    instance = new ActiveToken();
                return instance;
            }
        }

        public bool IsActive(string token)
        {
            var activeToken = from t in activeTokens
                       where t.Equals(token) 
                       select t;
            return activeToken != null;
        }

        public void Insert(string token)
        {
            activeTokens.Add(token);
        }

        public void Remove(string token)
        {
            activeTokens.Remove(token);
        }

    }
}
