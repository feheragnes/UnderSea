﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Dal.EntityTypeConfigurations
{
    public class CsapatConfiguration : IEntityTypeConfiguration<Csapat>
    {
        public void Configure(EntityTypeBuilder<Csapat> builder)
        {
            builder.HasOne(c => c.Celpont).WithMany(o => o.TamadoCsapats);
            builder.HasOne(c => c.Tulajdonos).WithMany(o => o.OtthoniCsapats);
        }
    }
}
