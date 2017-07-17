using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jambo.Infrastructure
{
    public class BloggingContext : DbContext, IUnitOfWork
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        private readonly IMediator _mediator;

        public BloggingContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);


            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2FNT1PQ;Database=Jambo;Trusted_Connection=True;");
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
