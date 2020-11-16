using System.Collections.Generic;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class VideoGameRepository : IRepository<VideoGame>
    {
        private readonly ApplicationDbContext db;
        public VideoGameRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<VideoGame> GetAll()
        {
            return db.VideoGames;
        }
        public VideoGame Get(int id)
        {
            return db.VideoGames.Find(id);
        }
        public void Create(VideoGame videoGame)
        {
            db.VideoGames.Add(videoGame);
        }
        public void Update(VideoGame videoGame)
        {
            db.VideoGames.Update(videoGame);
        }
        public void Delete(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame != null)
                db.VideoGames.Remove(videoGame);        
        }
    }
}
