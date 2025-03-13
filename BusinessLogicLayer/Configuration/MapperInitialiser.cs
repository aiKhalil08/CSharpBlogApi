using AutoMapper;
using DomainLayer.CommentDto;
using DomainLayer.DTO;
using DomainLayer.LikeDto;
using DomainLayer.Model;
using DomainLayer.PostDto;
using DomainLayer.UserDto;
using DomainLayer.TagDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Configuration
{
    public class MapperInitialiser: Profile
    {
        public MapperInitialiser()
        {
            //mappers for users
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            //mappers for posts
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count))
                .ReverseMap();

            //Mappers for comments
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();

            // Mappers for likes
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            //CreateMap<Like, UpdateLikeDto>().ReverseMap();
            CreateMap<Like, LikeDto>().ReverseMap();

            //Mappers for comments
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
        }
    }
}
