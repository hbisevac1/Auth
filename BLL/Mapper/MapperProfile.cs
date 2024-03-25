using System;
using AutoMapper;

namespace BLL.Mapper
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{

			CreateMap<DAL.Entities.User, BLL.DTOs.UserDto>().ReverseMap();
            CreateMap<DAL.Entities.Role, BLL.DTOs.RoleDto>().ReverseMap();
        }
	}
}

