using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COD3BR3AKR
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UserActive { get; set; }

        public User(){ }

        public User(string userName, string password)
        {
            this.UserId = UserManager.GetNewUserID();
            this.UserName = userName;
            this.Password = password;
            this.UserActive = true;
        }
    }


    public static class UserManager
    {
        public static int GetNewUserID()
        {
            int userID = 0;

            //TODO: get the latest id being used and increment by 1 as new userid

            return ++userID;
        }

        public static bool IsUserAuthPass(string username, string password)
        {
            bool userAuthicated = false;
            List<User> currentUsers = GetAllUsers();

            if (currentUsers.Count > 0)
            {
                foreach (User user in currentUsers)
                {
                    if (user.UserName == username && user.Password == password)
                    {
                        userAuthicated = true;
                        break;
                    }
                }
            }
            return userAuthicated;
        }

        public static bool IsUserExist(string userName)
        {
            bool userExist = false;
            List<User> currentUsers = GetAllUsers();

            if (currentUsers.Count > 0)
            {
                foreach (User user in currentUsers)
                {
                    if (user.UserName == userName)
                    {
                        userExist = true;
                        break;
                    }
                }
            }
            return userExist;
        }

        public static bool InactiveUser(string username)
        {
            User tempUser = new User();
            List<User> currentUsers = GetAllUsers();

            if (currentUsers.Count > 0)
            {
                foreach (User user in currentUsers)
                {
                    if (user.UserName == username)
                    {
                        tempUser = user;
                        break;
                    }
                }
            }

            tempUser.UserActive = false;

            return UpdateUser(tempUser);
        }

        public static bool AddNewUser(string username, string password)
        {
            User userTobeAdded = new User(username, password);

            Console.WriteLine("UserId -->" + userTobeAdded.UserId.ToString());
            Console.WriteLine("UserName -->" + userTobeAdded.UserName);
            Console.WriteLine("Password -->" + userTobeAdded.Password);


            //TODO: call XML Helper to add user info into XML file
            return true;
        }

        public static bool UpdateUser(User userTobeUpdated)
        {
            //TODO: update the node values via XML helper
            return true;
        }

        public static bool RemoveUser(User userToBeRemoved)
        {
            //TODO: call XML helper to remove node
            return true;
        }

        public static List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();

            //TODO: Read all users from XML file

            return userList;
        }

        internal static bool ResetUser(string userName, string password)
        {
            User tempUser = new User();
            List<User> currentUsers = GetAllUsers();

            if (currentUsers.Count > 0)
            {
                foreach (User user in currentUsers)
                {
                    if (user.UserName == userName)
                    {
                        tempUser = user;
                        break;
                    }
                }
            }

            tempUser.Password = password;

            return UpdateUser(tempUser);
        }
    }
}
