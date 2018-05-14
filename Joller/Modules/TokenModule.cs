using Newtonsoft.Json;
using System;
using Joller.Models;
using Joller.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Nancy;
using Nancy.ModelBinding;
using Joller.Repositories.Interfaces;
using Joller.Lib.Helpers;

namespace Joller.Modules
{

    public class TokenModule : NancyModule
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly JwtSigner _jwtSigner;
        public TokenModule(IUserRepository userRepository) : base("/token")
        {
            this._userRepository = userRepository;
            this._jwtSigner = new JwtSigner();
            this._passwordHasher = new PasswordHasher();

            Post("/auth", async args =>
            {
                // The user from the POST request
                var authUser = this.Bind<User>();

                // Find the user in the database
                var user = await this._userRepository.GetUser(authUser.Email);
                if (user == null)
                    return Response.AsJson(new { Status = "Error", Message = "User does not exist" });
                // Does the entered password match the password from the database
                var validPassword = this._passwordHasher.ValidatePassword(authUser.Password, user.Password, user.Salt);
                if (!validPassword)
                    return Response.AsJson(new { Status = "Error", Message = "Incorrect Password" });

                // Sign a token
                var token = this._jwtSigner.GenerateToken(user);

                return Response.AsJson(new { Status = "Success", Token = token });
            });
        }
    }
}
