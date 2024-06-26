﻿using System;
using DAL.Entities;

namespace BLL.DTOs
{
	public class UserDto
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public int RoleID { get; set; }

		public Role Role { get; set; }
		
	}
}

