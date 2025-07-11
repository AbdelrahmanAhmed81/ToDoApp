using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ToDo.Presistance.EntitesConfigurations
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks");
            builder.HasOne(t => t.User).WithMany(u => u.Tasks);

            builder.HasData(
                new TaskEntity()
                {
                    ID = Guid.Parse("3affb6b7-7eb8-4310-9123-61a47357d1f5"),
                    DueDate = new DateTime(2024, 02, 01),
                    Title = "call Ahmed",
                    Priority = Domain.Enums.TaskPriority.LowPriority,
                    IsDone = true,
                    UserId = Guid.Parse("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5"),
                    CreationDate = new DateTime(2024, 01, 29),
                    LastModificationDate = new DateTime(2024, 01, 29),
                    IsDeleted = false,
                    DeletionDate = null
                },
                new TaskEntity()
                {
                    ID = Guid.Parse("2efc9277-e5ff-4990-a317-370ca89a9024"),
                    DueDate = new DateTime(2026, 03, 28),
                    Title = "pay electricity bill",
                    Note = "here are some notes",
                    Priority = Domain.Enums.TaskPriority.HighPriority,
                    IsDone = false,
                    UserId = Guid.Parse("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5"),
                    CreationDate = new DateTime(2025, 06, 10),
                    LastModificationDate = new DateTime(2025, 06, 10),
                    IsDeleted = false,
                    DeletionDate = null
                },
                new TaskEntity()
                {
                    ID = Guid.Parse("91a92362-1c2e-4149-a84a-4d4d6a23c367"),
                    DueDate = new DateTime(2025, 12, 13),
                    Title = "prepare for christmas trip",
                    Note = "prepare your passport",
                    Priority = Domain.Enums.TaskPriority.MediumPriority,
                    IsDone = false,
                    UserId = Guid.Parse("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5"),
                    CreationDate = new DateTime(2025, 06, 25),
                    LastModificationDate = new DateTime(2025, 07, 10),
                    IsDeleted = true,
                    DeletionDate = new DateTime(2025, 07, 10)
                });
        }
    }
}
