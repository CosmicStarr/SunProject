using AutoMapper;
using Core.Data.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SunProject.DTO;
using SunProject.Errors;
using SunProject.Extenisons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SunProject.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser>signInManager,ITokenService TokenService,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = TokenService;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDTO>> LoginUser()
        {
            var CurrentUser = await _userManager.FindUserProperty(User);

            return new UserDTO
            {
                DisplayName = CurrentUser.DisplayName,
                Email = CurrentUser.Email,
                Token = _tokenService.CreateToken(CurrentUser)
            };
        }
        [HttpGet("EmailExist")]
        public async Task<ActionResult<bool>>EmailExist([FromQuery] string Email)
        {
            return await _userManager.FindByEmailAsync(Email) != null;
        }

        [HttpGet("Address")]
        public async Task<ActionResult<AddressDTO>>GetAddress()
        {
            var UserEmail = await _userManager.FindUserProperties(User);

            return _mapper.Map<Address, AddressDTO>(UserEmail.Address);
        }
        [HttpPut]
        public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO addressDTO)
        {
            var UpdatedAdd = await _userManager.FindUserProperties(User);
            UpdatedAdd.Address = _mapper.Map<AddressDTO, Address>(addressDTO);
            var result = await _userManager.UpdateAsync(UpdatedAdd);
            if(!result.Succeeded)
            {
                return BadRequest("Request not granted!");
            }
            return Ok(_mapper.Map<Address, AddressDTO>(UpdatedAdd.Address));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var User = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (User == null) return Unauthorized(new ApiResponse(401));
            var results = await _signInManager.CheckPasswordSignInAsync(User, loginDTO.Password, false);
            if (!results.Succeeded) return Unauthorized(new ApiResponse(401));
            return new UserDTO
            {
                Email = User.Email,
                DisplayName = User.UserName,
                Token = _tokenService.CreateToken(User)
            };
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var User = new AppUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName
            };

            var result = await _userManager.CreateAsync(User, registerDTO.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDTO
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = _tokenService.CreateToken(User)
            }; 

        }
    }
}
