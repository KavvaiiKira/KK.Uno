using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KK.Uno.Server.EF
{
    public class KKUnoDBContext : DbContext
    {
        public KKUnoDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<UserEntity> Users { get; set; }

        public virtual DbSet<RoleEntity> Roles { get; set; }

        public virtual DbSet<UserRoleEntity> UserRoles { get; set; }

        public virtual DbSet<GameEntity> Games { get; set; }

        public virtual DbSet<GameLogEntity> GameLogs { get; set; }

        public virtual DbSet<GameQueueEntity> Gamequeues { get; set; }

        public virtual DbSet<CardEntity> Cards { get; set; }

        public virtual DbSet<CardCollectionEntity> CardCollections { get; set; }

        public virtual DbSet<UserCardCollectionEntity> UserCardCollections { get; set; }

        public virtual DbSet<CardStateEntity> CardStates { get; set; }

        public virtual DbSet<UserGameStateEntity> UserGameStates { get; set; }

        public virtual DbSet<HubConnectionEntity> HubConnections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
