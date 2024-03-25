using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddUser(UserRegisterDto userRegisterDto)
        {
            var password = userRegisterDto.Password;

            if (!Regex.IsMatch(password, @"[!$%&.,]"))
            {
                throw new Exception("Password must contain at least one of the following special characters: ! $ % & .,");
            }

            GeneratePasswordHash(password, out byte[] passwordhash, out byte[] passwordsalt);

            User user = new User
            {
                Email = userRegisterDto.Email,
                PhoneNumber = userRegisterDto.PhoneNumber,
                PasswordHash = passwordhash,
                PasswordSalt = passwordsalt,
                RoleID = 1
            };

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        private void GeneratePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}

