using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Infrastructure.Data.Repositories;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class UserService  : IUserService
    {
        private readonly IUnitOfWork db;
        public UserService(IUnitOfWork context)
        {
            db = context;
        }
        public async Task<bool> Register(UserDTO model)
        {
            var user = await db.Users.FindByEmailAsync(model.Email);
            if(user == null)
            {
                user = new User { Email = model.Email, UserName = model.UserName};
                var checkCreation = await db.Users.CreateAsync(user, model.Password);

                var role = await db.Roles.FindByNameAsync(model.Role);
                if(role == null)
                {
                    await db.Roles.CreateAsync(new IdentityRole(model.Role));
                    role = await db.Roles.FindByNameAsync(model.Role);
                }
                await db.Users.AddToRoleAsync(user, role.Name);
                if (checkCreation.Succeeded)
                {
                    await db.SignIn.SignInAsync(user, false);
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> Login(UserDTO model)
        {
            var user = await db.Users.FindByEmailAsync(model.Email);
            if (user == null)
                return false;
            var checkPassword = await db.SignIn.CheckPasswordSignInAsync(user, model.Password, false);
            if (checkPassword.Succeeded)
            {
                await db.SignIn.SignInAsync(user, false);
                return true;
            }
            return false;
        }
        public async Task Logout()
        {
            await db.SignIn.SignOutAsync();
        }
    }
}
