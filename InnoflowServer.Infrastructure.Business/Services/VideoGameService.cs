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

        public IEnumerable<VideoGameDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<VideoGame>, List<VideoGameDTO>>(db.VideoGames.GetAll());
        }

        public bool Create(VideoGameDTO videoGameDTO)
        {
            var videoGame = db.VideoGames.Get(videoGameDTO.Id);

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

            db.VideoGames.Create(videoGame);
            db.Save();
            return true;
        }

        public VideoGameDTO Get(int id)
        {
            var videoGame = db.VideoGames.Get(id);

            if (videoGame == null)
            {
                return null;
            }

            return _mapper.Map<VideoGame, VideoGameDTO>(db.VideoGames.Get(id));
        }

        public bool Update(VideoGameDTO videoGameDTO)
        {
            var videoGame = db.VideoGames.Get(videoGameDTO.Id);

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

            db.VideoGames.Update(videoGame);
            db.Save();
            return true;
        }

        public bool Delete(int id)
        {
            VideoGame videoGame = db.VideoGames.Get(id);

            if (videoGame == null)
            {
                return false;

            }
            db.VideoGames.Delete(id);
            db.Save();
            return true;
        }
    }
}
