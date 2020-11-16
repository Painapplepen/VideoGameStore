using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Core.Models.Comment;
using VideoGameStore.Domain.Core.Models.Company;
using VideoGameStore.Domain.Core.Models.GameGenre;
using VideoGameStore.Domain.Core.Models.Order;
using VideoGameStore.Domain.Core.Models.VideoGame;

namespace VideoGameStore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserModel, UserDTO>();
            CreateMap<UserDTO, RegisterUserModel>();

            CreateMap<LoginUserModel, UserDTO>();
            CreateMap<UserDTO, LoginUserModel>();

            CreateMap<VideoGameDTO, VideoGame>();
            CreateMap<VideoGame, VideoGameDTO>();

            CreateMap<VideoGameCreateModel, VideoGameDTO>();
            CreateMap<VideoGameDTO, VideoGameCreateModel>();

            CreateMap<VideoGameUpdateModel, VideoGameDTO>();
            CreateMap<VideoGameDTO, VideoGameUpdateModel>();

            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();

            CreateMap<OrderCreateModel, OrderDTO>();
            CreateMap<OrderDTO, OrderCreateModel>();

            CreateMap<OrderUpdateModel, OrderDTO>();
            CreateMap<OrderDTO, OrderUpdateModel>();

            CreateMap<CommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();

            CreateMap<CommentCreateModel, CommentDTO>();
            CreateMap<CommentDTO, CommentCreateModel>();

            CreateMap<CommentUpdateModel, CommentDTO>();
            CreateMap<CommentDTO, CommentUpdateModel>();

            CreateMap<GameGenreDTO, GameGenre>();
            CreateMap<GameGenre, GameGenreDTO>();

            CreateMap<GameGenreCUModel, GameGenreDTO>();
            CreateMap<GameGenreDTO, GameGenreCUModel>();

            CreateMap<CompanyDTO, Company>();
            CreateMap<Company, CompanyDTO>();

            CreateMap<CompanyCreateModel, CompanyDTO>();
            CreateMap<CompanyDTO, CompanyCreateModel>();

            CreateMap<CompanyUpdateModel, CompanyDTO>();
            CreateMap<CompanyDTO, CompanyUpdateModel>();
        }
    }
}
