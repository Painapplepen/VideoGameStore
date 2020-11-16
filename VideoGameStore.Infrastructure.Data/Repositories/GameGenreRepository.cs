using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class GameGenreRepository : IRepository<GameGenre>
    {
        private readonly ApplicationDbContext db;
        
        public GameGenreRepository(ApplicationDbContext context)
        {
            db = context;
        }
       
        public IEnumerable<GameGenre> GetAll()
        {
            return db.GameGenres;
        }
       
        public GameGenre Get(int id)
        {
            return db.GameGenres.Find(id);
        }
       
        public void Create(GameGenre gameGenre)
        {
            db.GameGenres.Add(gameGenre);
        }
      
        public void Update(GameGenre gameGenre)
        {
            db.GameGenres.Update(gameGenre);
        }
       
        public void Delete(int id)
        {
            GameGenre gameGenre = db.GameGenres.Find(id);
            if (gameGenre != null)
                db.GameGenres.Remove(gameGenre);
        }
    }
}
