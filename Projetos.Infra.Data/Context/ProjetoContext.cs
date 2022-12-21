using Microsoft.EntityFrameworkCore;
using Projetos.Domain.Entities;
using System.Reflection;

namespace Projetos.Infra.Data.Context
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options) { }

        #region DbSets

        public DbSet<Projeto> Projeto { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
