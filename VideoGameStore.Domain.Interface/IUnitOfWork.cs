using Microsoft.AspNetCore.Identity;
using System;
using VideoGameStore.Domain.Core.Entities;

namespace VideoGameStore.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> Users { get; }
        RoleManager<IdentityRole> Roles { get; }
        SignInManager<User> SignIn { get; }

        IRepository<Comment> Comments { get; }
        IRepository<Company> Companies { get; }
        IRepository<VideoGame> VideoGames { get; }
        IRepository<Order> Orders { get; }
        IRepository<GameGenre> GameGenres { get; }

        void Save();
    }
}
