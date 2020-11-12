using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ApplicationDbContext db;
        public CommentRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }
        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }
        public void Create(Comment comment)
        {
            db.Comments.Add(comment);
        }
        public void Update(Comment comment)
        {
            db.Comments.Update(comment);
        }
        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
                db.Comments.Remove(comment);
        }
    }
}
