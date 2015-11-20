using System;

namespace MindEval.FiveSquare.Business
{
    public class CheckManager : ICheckManager
    {
        private AccountService _accountService;
        private Data.CheckRepository _checkRepository;

        public CheckManager()
        {
            _checkRepository = Data.CheckRepository.Instance;
            _accountService = new AccountService();
        }

        public void CheckIn(int id, string token)
        {
            _accountService.ValidateActiveToken(token);
            _checkRepository.CheckIn(id);
        }

        public void CheckOut(int id, string token)
        {
            _accountService.ValidateActiveToken(token);
            _checkRepository.CheckOut(id);
        }

        public int Count(int id, string token)
        {
            _accountService.ValidateActiveToken(token);
            return _checkRepository.Count(id);
        }

        public decimal Rate(int id, string token)
        {
            _accountService.ValidateActiveToken(token);
            return _checkRepository.Rate(id);
        }

        public void Rate(int id, int rate, string token)
        {
            _accountService.ValidateActiveToken(token);
            _checkRepository.Rate(id, rate);
        }

        public void Time(int id, string token)
        {
            throw new NotImplementedException();
        }
    }
}