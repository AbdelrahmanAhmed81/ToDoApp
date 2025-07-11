using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Domain.Common;

namespace ToDo.Presistance.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void ApplyGlobalSoftDeletedFilteration(this ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes()
               .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType));

            foreach (var entityType in entityTypes)
            {
                var parameter = Expression.Parameter(entityType.ClrType , "e");
                var property = Expression.Property(parameter , nameof(BaseEntity.IsDeleted));
                var constant = Expression.Constant(false);
                var equals = Expression.Equal(property , constant);
                var lambda = Expression.Lambda(equals , parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                modelBuilder.Entity(entityType.ClrType).HasIndex(nameof(BaseEntity.IsDeleted));
            }
        }
    }
}
