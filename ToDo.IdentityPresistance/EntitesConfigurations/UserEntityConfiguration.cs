using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.Identity;

namespace ToDo.IdentityPresistance.EntitesConfigurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            
            var passwordHasher = new PasswordHasher<User>();
            var email = "abdelrahman@test.com";
            var seedUser = new User
            {
                Id = Guid.Parse("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5") ,
                Email = email ,
                NormalizedEmail = email.ToUpper() ,
                UserName = email ,
                PhoneNumber = "224466889" ,
                NormalizedUserName = email.ToUpper() ,
                EmailConfirmed = true,
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now
            };
            seedUser.PasswordHash = passwordHasher.HashPassword(seedUser , "12345");

            builder.HasData(seedUser);
        }
    }
}
