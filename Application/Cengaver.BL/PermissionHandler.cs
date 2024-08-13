using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cengaver.Persistence;

namespace Cengaver.BL
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly DataContext _context;

        public PermissionHandler(DataContext context)
        {
            _context = context;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                context.Fail();
                return;
            }

            var userRole = await _context.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .FirstOrDefaultAsync(ur => ur.UserId == userId);

            if (userRole != null)
            {
                var rolePermissions = await _context.Permissions
                    .Where(p => p.RoleId == userRole.RoleId)
                    .ToListAsync();

                if (rolePermissions.Any(p => p.UserPermission == requirement.Permission))
                {
                    context.Succeed(requirement);
                }
            }
        }
    }

}
