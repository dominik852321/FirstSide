﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSide.Models.AdminInitialize
{
    public class UsersWithRolesConfig: IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string roleAdminId = "2301D884-221A-4E7D-B509-0113DCC043E1";

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            IdentityUserRole<string> iur = new IdentityUserRole<string>
            {
                RoleId = roleAdminId,
                UserId = adminId
            };
            builder.HasData(iur);
        }
    }
}
