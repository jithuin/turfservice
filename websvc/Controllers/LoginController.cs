using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using websvc.Models;


namespace websvc.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Mvc.AllowAnonymous]
    public class LoginController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Authenticate([FromBody] UserModel login)
        {
           // set un authorized first to the response
            IHttpActionResult response = BadRequest("username or passard incorrect");
             // if the user is authenticated then
            TurfUser user = AuthenticateUser(login);
            // if user is not null
            if (user != null)
            {

                // genarate the token for the user
                var tokenString = createToken(user);
                response = Ok( new {id=user.Id ,firstname=user.FirstName ,lastname=user.LastName , username=user.Username ,usertype=user.UserType ,email=user.Email, token = tokenString });
            }
            //return the response
            return response;
        }

        private string createToken(TurfUser userInfo)
        {
             var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim("UserType", userInfo.UserType.ToString ()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            var token = new JwtSecurityToken(issuer: "http://localhost:50191",
                audience: "http://localhost:50191",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

                       
        }

       private TurfUser AuthenticateUser(UserModel login)
        {
                      

            TurfUser turfUser = this.Credentials(login.Username, login.Password);
            if (turfUser == null)
            {
                return null;
            }

            return turfUser;

        }

        internal TurfUser Credentials(string username, string password)
        {
           var turfuser = this.db.TurfUsers
                    .Where(s => s.Username == username && s.Password == password)
                    .FirstOrDefault<TurfUser>();
            if (turfuser != null)
            {
                return turfuser;
            }
            else
            {
                return null;
            }
        }
    }
}
