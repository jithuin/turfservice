using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websvc.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoing { get; set; }
    }
}

//internal TurfUser Credentials(string username, string password)
//{
//    var turfuser = TurfUsers
//            .Where(s => s.Username == username && s.Password == password)
//            .FirstOrDefault<TurfUser>();
//    if (turfuser != null)
//    {
//        return turfuser;
//    }
//    else
//    {
//        return null;
//    }
//}