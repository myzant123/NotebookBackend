using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class NotebookContext : DbContext
{
    public NotebookContext(DbContextOptions<NotebookContext> options) : base(options)
    {
        
    }
    
    public DbSet<Note> Notes { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Note

        modelBuilder.Entity<Note>().ToTable("Notes");
        modelBuilder.Entity<Note>().HasKey(x => x.Id);
        modelBuilder.Entity<Note>()
            .Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Note>()
            .Property(x => x.Content)
            .HasMaxLength(2000);

        //One to one (NoteDetail)
        modelBuilder.Entity<Note>()
            .HasOne(x => x.Detail)
            .WithOne(y => y.Note)
            .HasForeignKey<NoteDetail>(z => z.NoteId);
        
        //One to many (Category)
        modelBuilder.Entity<Note>()
            .HasOne(x => x.Category)
            .WithMany(y => y.Notes)
            .HasForeignKey(c => c.CategoryId);
        
        #endregion

        #region Category

        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Category>().HasKey(s => s.Id);
        modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        #endregion

        #region NoteDetail

        modelBuilder.Entity<NoteDetail>().ToTable("NoteDetails");
        modelBuilder.Entity<NoteDetail>().HasKey(s => s.Id);
        modelBuilder.Entity<NoteDetail>()
            .Property(p => p.Created)
            .HasColumnType("datetime2").HasPrecision(0)
            .IsRequired();
        modelBuilder.Entity<NoteDetail>()
            .Property(p => p.LastModified)
            .HasColumnType("datetime2").HasPrecision(0)
            .IsRequired();
        
        #endregion
    }
}