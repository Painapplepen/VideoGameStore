using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class UnitOFWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        private DbRepository<VideoGame> videoGameRepository;
        private DbRepository<Comment> commentRepository;
        private DbRepository<Order> orderRepository;
        private DbRepository<GameGenre> gameGenreRepository;
        private DbRepository<Company> companyRepository;
       
        public UnitOFWork(ApplicationDbContext context, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
       
        public UserManager<User> Users 
        { 
            get 
            {
                return _userManager; 
            } 
        }
       
        public RoleManager<IdentityRole> Roles
        { 
            get 
            { 
                return _roleManager; 
            } 
        }
      
        public SignInManager<User> SignIn 
        {
            get 
            { 
                return _signInManager;
            } 
        }

        public IRepository<VideoGame> VideoGames
        {
            get
            {
                if (videoGameRepository == null)
                    videoGameRepository = new DbRepository<VideoGame>(db);
                return videoGameRepository;
            }
        }
       
        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new DbRepository<Comment>(db);
                return commentRepository;
            }
        }
      
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new DbRepository<Order>(db);
                return orderRepository;
            }
        }
       
        public IRepository<GameGenre> GameGenres
        {
            get
            {
                if (gameGenreRepository == null)
                    gameGenreRepository = new DbRepository<GameGenre>(db);
                return gameGenreRepository;
            }
        }
       
        public IRepository<Company> Companies
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new DbRepository<Company>(db);
                return companyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
