﻿using System;
namespace BLL.DTOs
{
	public class UserRegisterDto
	{
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
	}
}

