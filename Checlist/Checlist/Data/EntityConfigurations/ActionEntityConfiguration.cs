namespace Checlist.Data.EntityConfigurations
{
    using Checlist.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ActionEntityConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true)
                .IsUnicode(true);

            builder
                .Property(x => x.Date)
                .IsRequired(true);

            builder
                .Property(x => x.UserId)
                .IsRequired(true);

            builder
                .Property(x => x.State)
                .IsRequired(true);
        }
    }
}
