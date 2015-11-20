using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Business
{
    public class AccountService
    {
        private Data.ActiveToken _activeTokens;
        public AccountService() {
            _activeTokens = Data.ActiveToken.Instance;
        }

        public void ValidateActiveToken(string token)
        {
            if(!_activeTokens.IsActive(token))
                throw new DTO.MamalonaException(DTO.MamalonaMessage.UserIsNotLogged);
        }

        public void RegisterAccount(string token)
        {
            if(_activeTokens.IsActive(token))
                throw new DTO.MamalonaException(DTO.MamalonaMessage.UserAlreadyLogged);
            _activeTokens.Insert(token);
        }

        public void RemoveAccount(string token)
        {
            if (!_activeTokens.IsActive(token))
                throw new DTO.MamalonaException(DTO.MamalonaMessage.UserIsNotLogged);
        }
    }
}
