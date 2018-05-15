using Joller.Models;
using System;
using Nancy;
using Nancy.Security;
using Nancy.ModelBinding;
using Joller.Repositories.Interfaces;
using Joller.Lib.Helpers;
using System.Security.Claims;
using System.Collections.Generic;

namespace Joller
{

    public class UserModule : NancyModule
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        private async void InitAdmin()
        {

            var adminUser = await this._userRepository.GetUser("admin@admin.com");
            if (adminUser == null)
            {
                var encrypted = this._passwordHasher.Encrypt("admin");
                User newAdmin = new User
                {
                    Email = "admin@admin.com",
                    Password = encrypted[0],
                    Salt = encrypted[1],
                    Admin = true
                };
                await this._userRepository.AddUser(newAdmin);
            }
        }
        public UserModule(IUserRepository userRepository) : base("/users")
        {
            this._passwordHasher = new PasswordHasher();
            this._userRepository = userRepository;

            this.InitAdmin();

            Post("/signup", async args =>
            {
                var user = this.Bind<User>();

                // Encrypt Users password before storing the user
                var encrypted = this._passwordHasher.Encrypt(user.Password);

                user.Password = encrypted[0];
                user.Salt = encrypted[1];

                var Result = await this._userRepository.AddUser(user);

                if (!Result)
                {
                    return Response.AsJson(new
                    {
                        Status = "error",
                        message = "A user with that email already exist"
                    });
                }
                return Response.AsJson(new
                {
                    Status = "Success",
                    message = "User created, you can now sign in"
                });
            });
            Get("/", async args =>
            {
                this.RequiresAuthentication();
                this.RequiresClaims(c => c.Value.Equals("admin"));
                return await Response.AsJson(this._userRepository.GetAllUsers());
            });
        }
    }
}
