using Microsoft.EntityFrameworkCore;

namespace ProgramApplication;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Programs>().ToContainer("Programs");
        // modelBuilder.Entity<Question>().ToContainer("Questions").HasPartitionKey(q => q.ProgramId);
        modelBuilder.Entity<QuestionType>().ToContainer("QuestionTypes");
    }

    public DbSet<Programs> Programs { get; set; }
    // public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }

}
