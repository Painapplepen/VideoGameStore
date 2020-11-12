using Microsoft.AspNetCore.Identity;
using VideoGameStore.Domain.Core.Models;

namespace VideoGameStore.Domain.Interface
{
    public interface IUnitOfWork
    {
        UserManager<User> Users { get; }
        RoleManager<IdentityRole> Roles { get; }
        SignInManager<User> SignIn { get; }
        IRepository<Comment> Comment { get; }
        IRepository<Company> Company { get; }
        IRepository<VideoGame> VideoGame { get; }
        IRepository<Order> Order { get; }
        IRepository<GameGenre> GameGenre { get; }
    }
}
