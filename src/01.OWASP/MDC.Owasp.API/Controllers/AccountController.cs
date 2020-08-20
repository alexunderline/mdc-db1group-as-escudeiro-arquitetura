﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDC.Owasp.API.Infrastructure;
using MDC.Owasp.API.Infrastructure.Repositories;
using MDC.Owasp.API.Infrastructure.Services;
using MDC.Owasp.API.Models;
using MDC.Owasp.API.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MDC.Owasp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserRepository userRepository, ITokenService tokenService, ILogger<AccountController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userRepository.GetAllAsync();

            return users;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            if (request is null || string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }

            var user = await _userRepository.GetByLoginAndPasswordAsync(request.Login, request.Password);

            if (user is null)
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResponse(user.Id, user.Name, token);
        }
    }
}
