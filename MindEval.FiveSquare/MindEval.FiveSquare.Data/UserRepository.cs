using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Data
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class UserRepository
    {

        private static List<DTO.User> _users = new List<DTO.User>
        {
            new DTO.User {Id=1, Name="Martin", LastName="Robles", Sex="Male", Email="martin@gmail.com", Years=19 , Password="martin@123"},
            new DTO.User {Id=2, Name="Luis", LastName="Gonzalez", Sex="Male", Email="luis@gmail.com", Years=29 , Password="luis@123"},
            new DTO.User {Id=3, Name="Maria", LastName="Perez", Sex="Female", Email="maria@gmail.com", Years=27, Password="maria@123"},
            new DTO.User {Id=4, Name="Adriana", LastName="Ramirez", Sex="Female", Email="adriana@gmail.com", Years=45 , Password="adriana@123"},
            new DTO.User {Id=5, Name="Jorge", LastName="Fernandez", Sex="Male", Email="jorge@gmail.com", Years=90 , Password="jorge@123"}
        };

        public UserRepository()
        {

        }

        public List<DTO.User> GetUsers()
        {
            return _users;
        }

        public DTO.User GetUser(int Id)
        {
           return _users.FirstOrDefault(p => p.Id == Id);
        }
        public DTO.User GetUser(string email, string password)
        {
            return _users.FirstOrDefault(p => p.Email.Equals(email) && p.Password.Equals(password));
        }


    }
}
