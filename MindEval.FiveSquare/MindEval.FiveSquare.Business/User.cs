using System;
using System.Collections.Generic;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Business
{
    public class User
    {
        private Data.UserRepository _userRepository;

        public User()
        {
            _userRepository = new Data.UserRepository();
        }

        public User(Data.UserRepository repository)
        {
            _userRepository = repository;
        }

        public List<DTO.User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public DTO.User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }


        public bool Exists(string email, string password)
        {
            DTO.User user = _userRepository.GetUser(email, password);
            if (user == null)
                return false;
            return true;
        }

        public void Register(DTO.User userModel)
        {
            throw new NotImplementedException();
        }
    }
}