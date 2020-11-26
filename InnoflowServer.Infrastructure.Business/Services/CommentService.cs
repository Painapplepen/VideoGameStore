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
    public class CommentService : IService<CommentDTO>
    {
        private IUnitOfWork db { get; set; }
        private IMapper _mapper;

        public CommentService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            db = uow;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(await db.Comments.GetAllAsync());
        }

        public async Task<bool> CreateAsync(CommentDTO commentDTO)
        {
            var comment = await db.Comments.GetAsync(commentDTO.Id);

            if (comment != null)
            {
                return false;
            }

            comment = new Comment
            {
                UserId = commentDTO.UserId,
                Com = commentDTO.Com
            };

            await db.Comments.CreateAsync(comment);

            return true;
        }

        public async Task<CommentDTO> GetAsync(int id)
        {
            var comment = await db.Comments.GetAsync(id);

            if (comment == null)
            {
                return null;
            }

            return _mapper.Map<Comment, CommentDTO>(await db.Comments.GetAsync(id));
        }

        public async Task<bool> UpdateAsync(CommentDTO commentDTO)
        {
            var comment = await db.Comments.GetAsync(commentDTO.Id);

            if (comment == null)
            {
                return false;
            }

            comment = new Comment
            {
                Com = commentDTO.Com
            };

            await db.Comments.UpdateAsync(comment);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await db.Comments.GetAsync(id);

            if (comment == null)
            {
                return false;

            }

            return await db.Comments.DeleteAsync(id);
        }
    }
}

