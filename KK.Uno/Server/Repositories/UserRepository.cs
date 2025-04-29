using KK.Uno.Server.EF;
using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Repositories.Base.EntityRepository;
using KK.Uno.Server.Repositories.Base.ReadonlyRepository;

namespace KK.Uno.Server.Repositories
{
    public class UserRepository : EntityRepositry<UserEntity, KKUnoDBContext>, IAsyncRepository<UserEntity>
    {
        public UserRepository(KKUnoDBContext dbContext) : base(dbContext)
        {

        }
    }
}
