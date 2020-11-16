using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class GameGenreService : IService<GameGenreDTO>
    {
        private IUnitOfWork db { get; set; }
        private IMapper _mapper;

        public GameGenreService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            db = uow;
        }

        public IEnumerable<GameGenreDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<GameGenre>, List<GameGenreDTO>>(db.GameGenres.GetAll());
        }

        public bool Create(GameGenreDTO gameGenreDTO)
        {
            var gameGenre = db.GameGenres.Get(gameGenreDTO.Id);

            if (gameGenre != null)
            {
                return false;
            }

            gameGenre = new GameGenre
            {
                Name = gameGenreDTO.Name
            };

            db.GameGenres.Create(gameGenre);
            db.Save();
            return true;
        }

        public GameGenreDTO Get(int id)
        {
            var gameGenre = db.Orders.Get(id);

            if (gameGenre == null)
            {
                return null;
            }

            return _mapper.Map<GameGenre, GameGenreDTO>(db.GameGenres.Get(id));
        }

        public bool Update(GameGenreDTO gameGenreDTO)
        {
            var gameGenre = db.GameGenres.Get(gameGenreDTO.Id);

            if (gameGenre == null)
            {
                return false;
            }

            gameGenre = new GameGenre
            {
                Name = gameGenreDTO.Name
            };

            db.GameGenres.Update(gameGenre);
            db.Save();
            return true;
        }

        public bool Delete(int id)
        {
            GameGenre gameGenre = db.GameGenres.Get(id);

            if (gameGenre == null)
            {
                return false;

            }
            db.GameGenres.Delete(id);
            db.Save();
            return true;
        }
    }
}
