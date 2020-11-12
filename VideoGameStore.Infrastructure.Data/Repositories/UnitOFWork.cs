using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class UnitOFWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        private VideoGameRepository videoGameRepository;
        private CommentRepository commentRepository;
        private OrderRepository orderRepository;
        private GameGenreRepository gameGenreRepository;
        private CompanyRepository companyRepository;
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

        public IRepository<VideoGame> VideoGame
        {
            get
            {
                if (videoGameRepository == null)
                    videoGameRepository = new VideoGameRepository(db);
                return videoGameRepository;
            }
        }
        public IRepository<Comment> Comment
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }
        public IRepository<Order> Order
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<GameGenre> GameGenre
        {
            get
            {
                if (gameGenreRepository == null)
                    gameGenreRepository = new GameGenreRepository(db);
                return gameGenreRepository;
            }
        }
        public IRepository<Company> Company
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(db);
                return companyRepository;
            }
        }
    }
}
