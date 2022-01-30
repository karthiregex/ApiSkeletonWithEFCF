using HealthCare.BusinessLayer.Services.Repository;
using HealthCare.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare.BusinessLayer.ViewModels;

namespace HealthCare.BusinessLayer.Services
{
    public class LoanAdminServices
    {
        /// <summary>
        /// Creating instance/field of ILoanCustomerRepository and injecting into LoanCustomerSevices Constructor
        /// </summary>
        private readonly IHospitalAdminRepository _adminRepository;
        public LoanAdminServices(IHospitalAdminRepository loanAdminRepository)
        {
            _adminRepository = loanAdminRepository;
        }
        /// <summary>
        /// Create a new role if role is exists not possible to create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateRole(CreateRoleViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Disable an existing use if not required to work and login provide userId as GUID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IdentityResult> DisableUser(string userId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Edit an existing role if required using below method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> EditRole(EditRoleViewModel model)
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
        public async Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Provide different role for registered User
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IdentityResult> EditUsersInRole(UserRoleViewModel model, string roleId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Enable an existing user user id must be supplied GUID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IdentityResult> EnableUser(string userId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find user by user emailId
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserMaster> FindByEmailAsync(string email)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find an existing role by role id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IdentityRole> FindRoleByRoleId(string roleId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find an existing role by role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<IdentityRole> FindRoleByRoleName(string roleName)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// List all user role from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IdentityRole>> ListAllRole()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// List all user from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserMaster>> ListAllUser()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find an existing user bu userId Loginusing this method and return JWT token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<string> Login(LoginViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find user by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserMaster> FindUserByIdAsync(string userId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new user with default user role is customer
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IdentityResult> Register(UserMaster user, string password)
        {
            Task<IdentityResult> result = Task.FromResult<IdentityResult>(await _adminRepository.Register(user, password));
            return await result;
        }
    }
}
