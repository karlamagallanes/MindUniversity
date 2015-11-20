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
            string activeToken = activeTokens.FirstOrDefault(t => t.Equals(token));
            return !string.IsNullOrEmpty(activeToken);
            
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
