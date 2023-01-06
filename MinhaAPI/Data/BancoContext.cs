using Microsoft.EntityFrameworkCore;
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
            base.OnModelCreating(modelbuilder);
        }
    }
}
