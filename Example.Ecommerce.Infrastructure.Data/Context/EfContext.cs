using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Entity.Common;
using Example.Ecommerce.Infrastructure.Data.IntegrationData.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Example.Ecommerce.Infrastructure.Data.Context
{
    public class EfContext : DbContext
    {
        public virtual DbSet<CategoryEntity>? CategoryEntity { get; set; }
        public virtual DbSet<MessageEntity>? MessageEntity { get; set; }
        public virtual DbSet<MovieEntity>? MovieEntity { get; set; }
        public virtual DbSet<MovieCategoryEntity>? MovieCategoryEntity { get; set; }
        public virtual DbSet<PlanEntity>? PlanEntity { get; set; }
        public virtual DbSet<StateEntity>? StateEntity { get; set; }

        public EfContext(DbContextOptions<EfContext> dbContextOptions) : base(dbContextOptions) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            SetAuditableFileds();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SetAuditableFileds();
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddAuditFieldsConfiguration();
            modelBuilder.AddMoldelBuilderConfiguration();
        }

        private void SetAuditableFileds()
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateAt = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}