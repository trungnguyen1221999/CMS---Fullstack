using BlogProject.Api.Extensions;
using BlogProject.Core.Domain.Identity;
using BlogProject.Core.Models.System;
using BlogProject.Core.SeedWorks.Constants;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace BlogProject.Api.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public PermissionService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<string>> GetPermissionByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            var permissions = new List<string>();
            var allPermissions = new List<RoleClaimsDto>();
            if (roles.Contains(UserRoles.Admin))
            {
                var types = typeof(UserPermissions).GetTypeInfo().DeclaredNestedTypes;
                foreach( var type in types)
                {
                    allPermissions.GetPermissions(type);
                };

                permissions.AddRange(allPermissions.Select(x => x.Value));
            }
            else
            {
                foreach (var roleName in roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    var claims = await _roleManager.GetClaimsAsync(role);
                    var roleClaimValues = claims.Select(x => x.Value).ToList();
                    permissions.AddRange(roleClaimValues);
                }
            }
            return permissions.Distinct().ToList();
        }
    }
}
