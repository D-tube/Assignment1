using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class UserRepository
    {
        private static List<UserInformation> userReponses = new List<UserInformation>();
        public static void setUsers(UserInformation ui)
        {
            userReponses.Add(ui);
        }

        public static IEnumerable<UserInformation> GetUserByEmail(UserInformation ui)
        {
            foreach(UserInformation user in userReponses)
            {
                if (user.Email == ui.Email) yield return user;
            }
        }
        public static bool CheckEmail(UserInformation ui)
        {
            foreach(UserInformation user in userReponses)
            {
                if (ui.Email == user.Email) return true;
            }
            return false; 
        }

        public static bool getUser(UserInformation ui)
        {
            foreach (UserInformation user in userReponses)
            {
                if (ui.Email == user.Email) return true;
            }
            return false;
        }

        public static bool CheckPass(UserInformation ui)
        {
            foreach (UserInformation user in userReponses)
            {
                if (ui.Pass == user.Pass) return true;
            }
            return false;
        }

        public static IEnumerable<UserInformation> GetUsers => userReponses;


    }
}
