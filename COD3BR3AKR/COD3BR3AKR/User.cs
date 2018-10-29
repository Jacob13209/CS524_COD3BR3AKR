using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COD3BR3AKR
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UserActive { get; set; }

        public User(){ }

        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            this.UserActive = true;
        }

    }


    public static class UserManager
    {
        public static bool IsUserAuthPass(User currentUser)
        {

            return true;
        }

        public static bool IsUserExist(string userName)
        {

            return true;
        }

        public static bool AddNewUser(User userToBeAdded)
        {

            return true;
        }

        public static bool UpdateUser(User userTobeUpdated)
        {

            return true;
        }

        public static bool RemoveUser(User userToBeRemoved)
        {

            return true;
        }

        public static List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();

            return userList;
        }
    }
}
