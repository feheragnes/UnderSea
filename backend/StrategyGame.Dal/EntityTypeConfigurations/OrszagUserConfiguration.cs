using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

/*namespace StrategyGame.Dal.EntityTypeConfigurations
{
    public class OrszagUserConfiguration : IEntityTypeConfiguration<OrszagUser>
    {
        public void Configure(EntityTypeBuilder<OrszagUser> builder)
        {
            builder.HasKey(ou => new { ou.OrszagId, ou.UserId });
            builder.HasOne(ou => ou.User).WithMany(u => u.Orszags).HasForeignKey(ou => ou.UserId);
            builder.HasOne(ou => ou.Orszag).WithMany(o => o.Users).HasForeignKey(ou => ou.OrszagId);
        }
    }
}
*/