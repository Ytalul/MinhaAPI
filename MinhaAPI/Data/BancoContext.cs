using Microsoft.EntityFrameworkCore;
using MinhaAPI.Map;
using MinhaAPI.Models;

namespace MinhaAPI.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> configuracoes) : base (configuracoes)
        {}

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new UsuarioMap());
            modelbuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelbuilder);
        }
    }
}
