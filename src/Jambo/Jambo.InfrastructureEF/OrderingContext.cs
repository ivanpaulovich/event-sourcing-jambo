using Jambo.Domain.AggregatesModel.BuyerAggregate;
using Jambo.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jambo.InfrastructureEF
{
    public class OrderingContext
      : DbContext, IUnitOfWork

    {
        const string DEFAULT_SCHEMA = "ordering";

        public DbSet<PaymentMethod> Payments { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        //private readonly IMediator _mediator;

        public OrderingContext(DbContextOptions options /*, IMediator mediator*/) : base(options)
        {
            //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentMethod>(ConfigurePayment);
            modelBuilder.Entity<CardType>(ConfigureCardTypes);
            modelBuilder.Entity<Buyer>(ConfigureBuyer);
        }

        void ConfigureBuyer(EntityTypeBuilder<Buyer> buyerConfiguration)
        {
            buyerConfiguration.ToTable("buyers", DEFAULT_SCHEMA);

            buyerConfiguration.HasKey(b => b.Id);

            //buyerConfiguration.Ignore(b => b.DomainEvents);

            buyerConfiguration.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("buyerseq", DEFAULT_SCHEMA);

            buyerConfiguration.Property(b => b.IdentityGuid)
                .HasMaxLength(200)
                .IsRequired();

            buyerConfiguration.HasIndex("IdentityGuid")
              .IsUnique(true);

            buyerConfiguration.HasMany(b => b.PaymentMethods)
               .WithOne()
               .HasForeignKey("BuyerId")
               .OnDelete(DeleteBehavior.Cascade);

            var navigation = buyerConfiguration.Metadata.FindNavigation(nameof(Buyer.PaymentMethods));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        void ConfigurePayment(EntityTypeBuilder<PaymentMethod> paymentConfiguration)
        {
            paymentConfiguration.ToTable("paymentmethods", DEFAULT_SCHEMA);

            paymentConfiguration.HasKey(b => b.Id);

            //paymentConfiguration.Ignore(b => b.DomainEvents);

            paymentConfiguration.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("paymentseq", DEFAULT_SCHEMA);

            paymentConfiguration.Property<int>("BuyerId")
                .IsRequired();

            paymentConfiguration.Property<string>("CardHolderName")
                .HasMaxLength(200)
                .IsRequired();

            paymentConfiguration.Property<string>("Alias")
                .HasMaxLength(200)
                .IsRequired();

            paymentConfiguration.Property<string>("CardNumber")
                .HasMaxLength(25)
                .IsRequired();

            paymentConfiguration.Property<DateTime>("Expiration")
                .IsRequired();

            paymentConfiguration.Property<int>("CardTypeId")
                .IsRequired();

            paymentConfiguration.HasOne(p => p.CardType)
                .WithMany()
                .HasForeignKey("CardTypeId");
        }

        void ConfigureCardTypes(EntityTypeBuilder<CardType> cardTypesConfiguration)
        {
            cardTypesConfiguration.ToTable("cardtypes", DEFAULT_SCHEMA);

            cardTypesConfiguration.HasKey(ct => ct.Id);

            cardTypesConfiguration.Property(ct => ct.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            cardTypesConfiguration.Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //await _mediator.DispatchDomainEventsAsync(this);


            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
