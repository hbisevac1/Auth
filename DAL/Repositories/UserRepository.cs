﻿using System;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public AppDbContext _context;

		public UserRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
	}
}

