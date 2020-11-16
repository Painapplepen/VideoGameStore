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

        public IEnumerable<CommentDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(db.Comments.GetAll());
        }

        public bool Create(CommentDTO commentDTO)
        {
            var comment = db.Comments.Get(commentDTO.Id);

            if (comment != null)
            {
                return false;
            }

            comment = new Comment
            {
                UserId = commentDTO.UserId,
                Com = commentDTO.Com
            };

            db.Comments.Create(comment);
            db.Save();
            return true;
        }

        public CommentDTO Get(int id)
        {
            var comment = db.Comments.Get(id);

            if (comment == null)
            {
                return null;
            }

            return _mapper.Map<Comment, CommentDTO>(db.Comments.Get(id));
        }

        public bool Update(CommentDTO commentDTO)
        {
            var comment = db.Comments.Get(commentDTO.Id);

            if (comment == null)
            {
                return false;
            }

            comment = new Comment
            {
                Com = commentDTO.Com
            };

            db.Comments.Update(comment);
            db.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Comment comment = db.Comments.Get(id);

            if (comment == null)
            {
                return false;

            }
            db.Comments.Delete(id);
            db.Save();
            return true;
        }
    }
}
