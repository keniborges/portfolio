using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projetos.Domain.Entities;

namespace Projetos.Infra.Data.Configurators
{
    public abstract class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).IsRequired();

            InternalConfigure(builder);
        }

        protected abstract void InternalConfigure(EntityTypeBuilder<TEntity> builder);
    }
}
