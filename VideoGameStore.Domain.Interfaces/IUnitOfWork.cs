using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.
using VideoGameStore.Domain.Core.Models;

namespace VideoGameStore.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> Users { get; }
        RoleManager<IdentityRole> Roles { get; }
        SignInManager<User> SignIn { get; }

        IRepository<VideoGame> Marks { get; }
        IRepository<Model> Models { get; }
        IRepository<Auto> Autos { get; }
        IRepository<Attachment> Attachments { get; }

        void Save();
    }
}
