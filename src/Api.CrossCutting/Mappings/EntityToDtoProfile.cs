using Api.Domain.Entities;
using AutoMapper;
using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
{
        public EntityToDtoProfile()
        {
            CreateMap<UserDtoCreate, UserEntity>()
                .ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();
        }    
    }
}
