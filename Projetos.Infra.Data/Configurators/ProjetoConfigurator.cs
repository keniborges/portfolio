using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projetos.Domain.Entities;

namespace Projetos.Infra.Data.Configurators
{
    public class ProjetoConfigurator : BaseEntityConfigurator<Projeto>
    {
        protected override void InternalConfigure(EntityTypeBuilder<Projeto> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.OrcamentoTotal).IsRequired(true);
        }
    }
}
