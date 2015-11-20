using System.Collections.Generic;
using System.Linq;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Data
{
    public class UserRepository
    {
        private List<DTO.User> users;
        private static UserRepository instance;

        private UserRepository()
        {
            users = new List<DTO.User>
            {
                new DTO.User {Id=1, Name="Martin", LastName="Robles", Sex="Male", Email="martin@gmail.com", Years=19 , Password="martin@123"},
                new DTO.User {Id=2, Name="Luis", LastName="Gonzalez", Sex="Male", Email="luis@gmail.com", Years=29 , Password="luis@123"},
                new DTO.User {Id=3, Name="Maria", LastName="Perez", Sex="Female", Email="maria@gmail.com", Years=27, Password="maria@123"},
                new DTO.User {Id=4, Name="Adriana", LastName="Ramirez", Sex="Female", Email="adriana@gmail.com", Years=45 , Password="adriana@123"},
                new DTO.User {Id=5, Name="Jorge", LastName="Fernandez", Sex="Male", Email="jorge@gmail.com", Years=90 , Password="jorge@123"}
            };
        }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        public DTO.User FindUserById(int id)
        {
            var user = from u in users
                       where u.Id == id
                       select u;
            return (DTO.User)user;
        }

        public bool Exist(string email, string password)
        {
            var user = from u in users
                       where u.Email.Equals(email) && password.Equals(password)
                       select u;
            return user != null;
        }

        public int Insert(DTO.User user)
        {
            int newId = users.Select(p => p.Id).Max() + 1;
            user.Id = newId;
            users.Add(user);
            return newId;
        }
    }
}