using ALB.Cliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALB.Cliente.Infrastruture.DataBases
{
    public class ClienteEntityConfigurations : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.Notifications);
            builder.ToTable("Cliente").HasKey(x => new { x.Id });            
        }
    }
}
