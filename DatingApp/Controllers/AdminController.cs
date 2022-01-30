using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.BusinessLayer.Interfaces;

using DatingApp.Entities;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Creating referance object of UserManager and RoleManager class and injecting in controller constructor
        /// </summary>
        private readonly UserManager<UserMaster> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAdminServices _adminServices;

        public AdminController(UserManager<UserMaster> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IAdminServices adminServices)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            _configuration = configuration;
            _adminServices = adminServices;
        }
        /// <summary>
        /// Login User using this method and return back with JWT tokec for validation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            //Check if user is disable or Enable
            //if (user.Enabled == true)
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Id exists but locked, Contact Admin!" });

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        /// <summary>
        /// Register new user for enroll in different role after that, make sure user is allready-
        /// register or not if register return error using FindByEmailAsync method.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register/{password}")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] UserMaster model, string password)
        {
            var reTask = _adminServices.Register(model, password);
            return (IActionResult)reTask;
        }
        /// <summary>
        /// Create a new role if role is exists not possible to create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Provide different role for registered use. 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("editusers-role/{roleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsersInRole([FromBody] UserRoleViewModel model, string roleId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Edit register user or change user password only, UserName/Name and Email are not change and must provide
        /// Change user Password only - Applicable using below method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("change-password")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePasswordViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Edit an existing role if required using below method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// List all an existing in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<IdentityRole>> ListRole()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// List an all existing user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list-users")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<UserMaster>> ListUser()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Disable an existing use if not required to work and login provide userId as GUID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("disable-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DisableUser(string userId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Enable an existing user use id must be supplied GUID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("enable-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EnableUser(string userId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
