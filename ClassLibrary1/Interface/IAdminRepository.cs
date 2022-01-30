using DatingApp.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.RepositoryLayer.Interface
{
    public interface IAdminRepository
    {
        Task<IActionResult> Login(LoginViewModel model);
        Task<IdentityResult> Register(UserMaster user, string password);
        Task<IdentityResult> CreateRole(CreateRoleViewModel model);
        Task<IdentityResult> EditUsersInRole(UserRoleViewModel model, string roleId);
        Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel model);
        Task<IdentityResult> EditRole(EditRoleViewModel model);
        Task<IdentityRole> FindRoleByRoleName(string roleName);
        Task<IdentityRole> FindRoleByRoleId(string roleId);
        Task<IEnumerable<IdentityRole>> ListAllRole();
        Task<IEnumerable<UserMaster>> ListAllUser();
        Task<IdentityResult> DisableUser(string userId);
        Task<IdentityResult> EnableUser(string userId);
        Task<UserMaster> FindByEmailAsync(string email);
        Task<UserMaster> FindUserByIdAsync(string userId);
    }
}
