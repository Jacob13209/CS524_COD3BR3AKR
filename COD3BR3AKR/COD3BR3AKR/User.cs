using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace COD3BR3AKR
{
    [XmlRoot("User")]
    public class User
    {
        [XmlAttribute("ID")]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }

        public User(){ }

        public User(int userID, string userName, string password, string status="ACTIVE")
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.UserStatus = status;
        }
    }

    public static class UserManager
    {
        public static void InitializeInitialUserID()
        {
            INIFile myINIFile = new INIFile(AccountManagement.USER_ID_INIT);

            myINIFile.IniWriteValue("System User ID Control", "Next Available User ID", "1");
        }

        private static int GetNewUserID()
        {
            int currentUserID = 0;
            int nextUserID = 0;
            string strUserID = string.Empty;

            INIFile myINIFile = new INIFile(AccountManagement.USER_ID_INIT);

            strUserID = myINIFile.IniReadValue("System User ID Control", "Next Available User ID");

            try
            {
                currentUserID = Convert.ToInt32(strUserID);
                nextUserID = currentUserID + 1;
                // update the INI file to generate a new user id
                myINIFile.IniWriteValue("System User ID Control", "Next Available User ID", (nextUserID).ToString());
            }
            catch { }

            return currentUserID;
        }

        public static string GetUserNameBasedOnID(string userID)
        {
            string nodeName = string.Format("Users/User[@ID='{0}']", userID);

            return XMLHelper.Read(AccountManagement.USER_INFO_CONFIG, nodeName, "UserName");
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

        public static bool IsUserActive(string username)
        {
            bool userActive = false;
            List<User> currentUsers = GetAllUsers();

            if (currentUsers.Count > 0)
            {
                foreach (User user in currentUsers)
                {
                    if (user.UserName == username && user.UserStatus == "ACTIVE")
                    {
                        userActive = true;
                        break;
                    }
                }
            }
            return userActive;
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

            tempUser.UserStatus = "INACTIVE";
            return UpdateUser(tempUser);
        }

        public static bool AddNewUser(string username, string password, string status="ACTIVE")
        {
            bool addResult = false;
            string tempUserXML = Application.StartupPath + @"\tempuser.xml";

            #region XML Serialization
            XmlSerializer serializer;

            User newUser = new User(GetNewUserID(), username, password);

            // Empty namespace 
            XmlSerializerNamespaces nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add(string.Empty, string.Empty);

            try
            {
                // first user being added to the system
                if (File.Exists(AccountManagement.USER_INFO_CONFIG) == false)
                {
                    List<User> userList = new List<User>();
                    userList.Add(newUser);

                    serializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("Users"));

                    using (TextWriter writer = new StreamWriter(AccountManagement.USER_INFO_CONFIG))
                    {
                        serializer.Serialize(writer, userList, nameSpace);
                    }
                    addResult = true;
                }
                else
                {
                    serializer = new XmlSerializer(typeof(User));

                    // serialize the object
                    using (TextWriter writer = new StreamWriter(tempUserXML))
                    {
                        serializer.Serialize(writer, newUser, nameSpace);
                    }

                    // add this serialized object to existing file
                    if (AddUserToExistingSystem(tempUserXML) == true)
                    {
                        File.Delete(tempUserXML);
                        addResult = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region XML Helper
            //TODO: call XML Helper to add user info into XML file

            //XMLHelper.Insert(AccountManagement.USER_INFO_CONFIG, "Users", "User", "ID", newUserID.ToString());
            //userRoot = string.Format("Users/User[@ID='{0}']", newUserID.ToString());

            //XMLHelper.Insert(AccountManagement.USER_INFO_CONFIG, userRoot, "UserName", "", username);
            //XMLHelper.Insert(AccountManagement.USER_INFO_CONFIG, userRoot, "Password", "", password);
            //XMLHelper.Insert(AccountManagement.USER_INFO_CONFIG, userRoot, "UserStatus", "", "ACTIVE");
            #endregion
            return addResult;
        }

        private static bool AddUserToExistingSystem(string tempUserXML)
        {
            try
            {
                // Current user file
                XmlDocument currentUsers = new XmlDocument();
                currentUsers.Load(AccountManagement.USER_INFO_CONFIG);

                //Tmep XML file for new user
                XmlDocument newUser = new XmlDocument();
                newUser.Load(tempUserXML);

                //Append the node for new user to existing user file
                XmlNode newUserNode = currentUsers.ImportNode(newUser.DocumentElement, true);
                currentUsers.DocumentElement.AppendChild(newUserNode);

                currentUsers.Save(AccountManagement.USER_INFO_CONFIG);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateUser(User userTobeUpdated)
        {
            bool retRes = true;
            string nodeStr = string.Format("Users/User[@ID='{0}']", userTobeUpdated.UserID);

            try
            {
                retRes &= XMLHelper.Update(AccountManagement.USER_INFO_CONFIG, nodeStr+"/UserName", "", userTobeUpdated.UserName);
                retRes &= XMLHelper.Update(AccountManagement.USER_INFO_CONFIG, nodeStr+"/Password", "", userTobeUpdated.Password);
                retRes &= XMLHelper.Update(AccountManagement.USER_INFO_CONFIG, nodeStr+"/UserStatus","", userTobeUpdated.UserStatus);
            }
            catch
            {
                retRes = false;
            }
            return retRes;
        }

        public static bool UpdateUser(string userID, string userstatus)
        {
            User tempUser = new User();
            List<User> currentUsers = GetAllUsers();

            if (currentUsers.Count > 0)
            {
                foreach (User user in currentUsers)
                {
                    if (user.UserID.ToString() == userID)
                    {
                        tempUser = user;
                        break;
                    }
                }
            }

            tempUser.UserStatus = userstatus;
            return UpdateUser(tempUser);
        }

        public static bool RemoveUser(string userID)
        {
            string nodeName = string.Format("Users/User[@ID='{0}']", userID);

            // remove entire node           
            return XMLHelper.Delete(AccountManagement.USER_INFO_CONFIG, nodeName, string.Empty);
        }

        public static List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            try
            {                
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                using (var reader = new StreamReader(AccountManagement.USER_INFO_CONFIG))
                {
                    XmlSerializer deserializer = new XmlSerializer( typeof(List<User>),
                                                                    new XmlRootAttribute("Users"));
                    userList = (List<User>)deserializer.Deserialize(reader);
                }
            }
            catch { }
            return userList;
        }

        public static bool ResetUser(string userName, string password)
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
            tempUser.UserStatus = "ACTIVE";
            return UpdateUser(tempUser);
        }
    }
}
