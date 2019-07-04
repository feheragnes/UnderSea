using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Model.Entities.Models.Egysegek;

namespace StrategyGame.Dal.EntityTypeConfigurations
{
    public class EgysegConfiguration : IEntityTypeConfiguration<Egyseg>
    {
        public void Configure(EntityTypeBuilder<Egyseg> builder)
        {
            builder.HasOne(e => e.BirtokosCsapat).WithMany(c => c.Egysegs);
            builder.HasOne(e => e.TamadottCsapat).WithMany(c => c.VedekezoEgysegs);

        }
    }
}
