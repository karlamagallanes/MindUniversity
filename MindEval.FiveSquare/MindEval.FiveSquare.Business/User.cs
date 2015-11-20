using MindEval.FiveSquare.Helpers;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Business
{
    public class User
    {
        private AccountService _accountService;
        private Data.UserRepository _userRepository;

        public User()
        {
            _userRepository = Data.UserRepository.Instance;
            _accountService = new AccountService();
        }

        public DTO.User GetUser(int id)
        {
            return _userRepository.FindUserById(id);
        }

        public string Login(string email, string password)
        {
            if (!Exists(email, password))
                throw new DTO.MamalonaException(DTO.MamalonaExceptionMessage.BadUserLogin);
            string token = CreateToken(email, password);
            _accountService.RegisterAccount(token);
            return token;
        }

        public void Logout(string token)
        {
            _accountService.RemoveAccount(token);
        }

        public void Register(DTO.User userModel)
        {
            Validate(userModel);
            int newId = _userRepository.Insert(userModel);
            if (newId == 0)
                throw new DTO.MamalonaException(DTO.MamalonaExceptionMessage.BadUserRegister);
        }

        private string CreateToken(string email, string password)
        {
            string token = TrucutruEncriptationService.Crypt(string.Format("{0}:{1}", email, password));
            if (string.IsNullOrEmpty(token))
                throw new DTO.MamalonaException(DTO.MamalonaExceptionMessage.BadTokenCreation);
            return token;
        }

        private bool Exists(string email, string password)
        {
            return _userRepository.Exist(email, password);
        }

        private void Validate(DTO.User user)
        {
            bool flag = false;

            if (string.IsNullOrEmpty(user.Name)) flag = true;
            else if (user.Years == 0) flag = true;
            else if (string.IsNullOrEmpty(user.Email)) flag = true;
            else if (string.IsNullOrEmpty(user.Email)) flag = true;
            else if (string.IsNullOrEmpty(user.Password)) flag = true;
            if (flag)
                throw new DTO.MamalonaException(DTO.MamalonaExceptionMessage.MissingInformationRequired);
        }
    }
}