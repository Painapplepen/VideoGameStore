using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class CommentService : IService<Comment>
    {
        private readonly IRepository<Comment> comments;
        public CommentService(IRepository<Comment> commentRepository)
        {
            comments = commentRepository;
        }
        public IEnumerable<Comment> GetAll()
        {
            return comments.GetAll();
        }
        public bool Create(Comment comment)
        {
            comments.Create(comment);
            return true;
        }
        public Comment Get(int id)
        {
            return comments.Get(id);
        }
        public bool Update(Comment comment)
        {
            comments.Update(comment);
            return true;
        }
        public bool Delete(int id)
        {
            comments.Delete(id);
            return true;
        }
    }
}
