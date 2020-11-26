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

        public async Task<IEnumerable<GameGenreDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GameGenre>, List<GameGenreDTO>>(await db.GameGenres.GetAllAsync());
        }

        public async Task<bool> CreateAsync(GameGenreDTO gameGenreDTO)
        {
            var gameGenre = await db.GameGenres.GetAsync(gameGenreDTO.Id);

            if (gameGenre != null)
            {
                return false;
            }

            gameGenre = new GameGenre
            {
                Name = gameGenreDTO.Name
            };

            await db.GameGenres.CreateAsync(gameGenre);

            return true;
        }

        public async Task<GameGenreDTO> GetAsync(int id)
        {
            var gameGenre = await db.GameGenres.GetAsync(id);

            if (gameGenre == null)
            {
                return null;
            }

            return _mapper.Map<GameGenre, GameGenreDTO>(await db.GameGenres.GetAsync(id));
        }

        public async Task<bool> UpdateAsync(GameGenreDTO gameGenreDTO)
        {
            var gameGenre = await db.GameGenres.GetAsync(gameGenreDTO.Id);

            if (gameGenre == null)
            {
                return false;
            }

            gameGenre = new GameGenre
            {
                Name = gameGenreDTO.Name
            };

            await db.GameGenres.UpdateAsync(gameGenre);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var gameGenre = await db.GameGenres.GetAsync(id);

            if (gameGenre == null)
            {
                return false;
            }

            return await db.GameGenres.DeleteAsync(id);
        }
    }
}
