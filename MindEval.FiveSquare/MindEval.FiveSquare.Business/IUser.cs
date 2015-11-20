using System.Collections.Generic;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Business
{
    public interface IUser
    {
        DTO.User GetUser(int id);

        List<DTO.User> GetUsers();

        string Login(string email, string password);

        void Logout(string token);

        void Register(DTO.User user);

        
    }
}