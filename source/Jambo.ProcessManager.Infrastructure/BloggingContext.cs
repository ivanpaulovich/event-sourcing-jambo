using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading;
using System.Threading.Tasks;

namespace Jambo.ProcessManager.Infrastructure
{
    public class BloggingContext : DbContext, IUnitOfWork
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            int result = await base.SaveChangesAsync();

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(ConfigureBlogs);
            modelBuilder.Entity<Post>(ConfigurePosts);
        }

        private void ConfigureBlogs(EntityTypeBuilder<Blog> requestConfiguration)
        {
            requestConfiguration.ToTable("Blog");
            requestConfiguration.HasKey(cr => cr.Id);
            requestConfiguration.Property(cr => cr.Url).IsRequired();
            requestConfiguration.Property(cr => cr.Rating).IsRequired();
        }

        private void ConfigurePosts(EntityTypeBuilder<Post> requestConfiguration)
        {
            requestConfiguration.ToTable("Post");
            requestConfiguration.HasKey(cr => cr.Id);
            requestConfiguration.Property(cr => cr.Title).IsRequired();
            requestConfiguration.Property(cr => cr.Content).IsRequired();
            requestConfiguration.Property(cr => cr.BlogId).IsRequired();
        }
    }
}
