using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSide.Models.AdminInitialize
{
    public class RoleConfiguration: IEntityTypeConfiguration<IdentityRole>
    {
        private const string roleAdminId = "2301D884-221A-4E7D-B509-0113DCC043E1";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id=roleAdminId,
                    Name="Admin",
                    NormalizedName="ADMIN"
                }
                );
        }
    }
}
