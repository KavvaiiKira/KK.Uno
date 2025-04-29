using KK.Uno.Server.Constants;
using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Repositories.Base.ReadonlyRepository;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.Services
{
    public class RoleService : IRoleService
    {
        private readonly IAsyncRepository<RoleEntity> _roleRepository;

        public RoleService(IAsyncRepository<RoleEntity> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Guid>> GetDefaultRoleIdsAsync()
        {
            var defaultRoles = Roles.GetDefaultRoles();

            var roles = await _roleRepository
                .GetAll()
                .Where(r => defaultRoles.Contains(r.Name))
                .ToListAsync();

            return roles.Select(r => r.Id);
        }
    }
}
