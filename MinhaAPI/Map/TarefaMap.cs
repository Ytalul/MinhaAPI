using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAPI.Models;

namespace MinhaAPI.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(tarefa => tarefa.Id);
            builder.Property(tarefa => tarefa.Nome).IsRequired().HasMaxLength(255);
            builder.Property(tarefa => tarefa.Descrição).HasMaxLength(1000);
            builder.Property(tarefa => tarefa.Status).IsRequired();
            builder.Property(tarefa => tarefa.UsuarioId);
            builder.HasOne(tarefa => tarefa.Usuario);
        }
    }
}
