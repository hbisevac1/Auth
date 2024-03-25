using System;
using BLL.DTOs;

namespace BLL.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> AddUser(UserRegisterDto userRegisterDto);
	}
}

