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
    public class GameGenreService : IService<GameGenre>
    {
        private readonly IRepository<GameGenre> gameGenres;
        public GameGenreService(IRepository<GameGenre> gameGenreRepository)
        {
            gameGenres = gameGenreRepository;
        }
        public IEnumerable<GameGenre> GetAll()
        {
            return gameGenres.GetAll();
        }
        public bool Create(GameGenre gameGenre)
        {
            gameGenres.Create(gameGenre);
            return true;
        }
        public GameGenre Get(int id)
        {
            return gameGenres.Get(id);
        }
        public bool Update(GameGenre gameGenre)
        {
            gameGenres.Update(gameGenre);
            return true;
        }
        public bool Delete(int id)
        {
            gameGenres.Delete(id);
            return true;
        }
    }
}
