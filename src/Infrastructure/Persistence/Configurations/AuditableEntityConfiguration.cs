using micro_api.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace micro_api.Infrastructure.Persistence.Configurations
{
    class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntity>
    {
        public void Configure(EntityTypeBuilder<AuditableEntity> builder)
        {
            builder.Ignore(p => p.DomainEvents);
        }
    }
}
