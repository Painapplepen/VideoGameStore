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
    public class VideoGameService : IService<VideoGame>
    {
        private readonly IRepository<VideoGame> videoGames;
        public VideoGameService(IRepository<VideoGame> videoGameRepository)
        {
            videoGames = videoGameRepository;
        }
        public IEnumerable<VideoGame> GetAll()
        {
            return videoGames.GetAll();
        }
        public bool Create(VideoGame videoGame)
        {
            videoGames.Create(videoGame);
            return true;
        }
        public VideoGame Get(int id)
        {
            return videoGames.Get(id);
        }
        public bool Update(VideoGame videoGame)
        {
            videoGames.Update(videoGame);
            return true;
        }
        public bool Delete(int id)
        {
            videoGames.Delete(id);
            return true;
        }
    }
}
