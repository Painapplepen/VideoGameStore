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
    public class VideoGameService : IService<VideoGameDTO>
    {
        private IUnitOfWork db { get; set; }
        private IMapper _mapper;

        public VideoGameService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            db = uow;
        }

        public  async Task<IEnumerable<VideoGameDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<VideoGame>, List<VideoGameDTO>>(await db.VideoGames.GetAllAsync());
        }

        public async Task<bool> CreateAsync(VideoGameDTO videoGameDTO)
        {
            var videoGame = await db.VideoGames.GetAsync(videoGameDTO.Id);

            if (videoGame != null)
            {
                return false;
            }

            videoGame = new VideoGame
            {
                Name = videoGameDTO.Name,
                Type = videoGameDTO.Type,
                Rating = videoGameDTO.Rating,
                Year = videoGameDTO.Year,
                Cost = videoGameDTO.Cost,
            };

            await db.VideoGames.CreateAsync(videoGame);

            return true;
        }

        public async Task<VideoGameDTO> GetAsync(int id)
        {
            var videoGame = await db.VideoGames.GetAsync(id);

            if (videoGame == null)
            {
                return null;
            }

            return _mapper.Map<VideoGame, VideoGameDTO>(await db.VideoGames.GetAsync(id));
        }

        public async Task<bool> UpdateAsync(VideoGameDTO videoGameDTO)
        {
            var videoGame = await db.VideoGames.GetAsync(videoGameDTO.Id);

            if (videoGame == null)
            {
                return false;
            }

            videoGame = new VideoGame
            {
                Name = videoGameDTO.Name,
                Type = videoGameDTO.Type,
                Cost = videoGameDTO.Cost,
            };

            await db.VideoGames.UpdateAsync(videoGame);
            db.Save();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var videoGame = await db.VideoGames.GetAsync(id);

            if (videoGame == null)
            {
                return false;
            }

            return await db.VideoGames.DeleteAsync(id);
        }
    }
}
