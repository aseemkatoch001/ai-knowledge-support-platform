using AiKnowledge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pgvector;

namespace AiKnowledge.Infrastructure.Persistence.Configurations;

public class DocumentChunkConfiguration : IEntityTypeConfiguration<DocumentChunk>
{
    public void Configure(EntityTypeBuilder<DocumentChunk> builder)
    {
        builder.ToTable("document_chunks");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ChunkIndex)
            .IsRequired();

        builder.Property(x => x.Text)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        var embeddingConverter = new ValueConverter<float[]?, Vector?>(
           value => value == null ? null : new Vector(value),
           value => value == null ? null : value.ToArray());

        builder.Property(x => x.Embedding)
            .HasConversion(embeddingConverter)
            .HasColumnType("vector(768)");



        builder.HasOne(x => x.Document)
            .WithMany(x => x.Chunks)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.DocumentId,
            x.ChunkIndex
        })
        .IsUnique();

       
    }
}
