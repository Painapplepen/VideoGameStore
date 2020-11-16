using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Models;

namespace VideoGameStore.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(UserDTO user);
        
        Task<bool> Login(UserDTO user);
        
        Task Logout();
    }
}
