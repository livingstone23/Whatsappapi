using ACD.Domain.Models;
using Microsoft.EntityFrameworkCore;



namespace ACD.Infrastructure.Context;


/// <summary>
/// Class responsible for managing the context between the database and the entities mapped in the application.
/// </summary>
public class ACDDbContext: DbContext 
{

    
    public ACDDbContext(DbContextOptions options) : base(options) { }


    /// <summary>
    /// Represents a collection of BalanceServiceProvider entities in the database.
    /// </summary>
    public DbSet<BalanceServiceProvider> BalanceServiceProviders { get; set; }


    public DbSet<WhatsAppMessage> WhatsAppMessages { get; set; }


    /// <summary>
    /// Overrides the default behavior of model creation to configure the entity mappings for the BalanceServiceProvider table in the database.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
    
    /// <summary>
    /// Overrides the default behavior of model creation to configure the entity mappings for the BalanceServiceProvider table in the database.
    /// </summary>
    /// <value></value>
    modelBuilder.Entity<BalanceServiceProvider>(entity =>
    {


        entity.ToTable("BalanceServiceProvider", schema: "dbo");


        entity.HasKey(e => e.Id);


        entity.Property(e => e.BusinessId)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(true);


        entity.Property(e => e.BspCode)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);


        entity.Property(e => e.BspName)
            .IsRequired()
            .HasMaxLength(250)
            .IsUnicode(false);


        entity.Property(e => e.CodingScheme)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);


        entity.Property(e => e.Country)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false);

        entity.Property(e => e.ValidityStart)
            .IsRequired();


        entity.Property(e => e.ValidityEnd)
            .IsRequired();


        entity.Property(e => e.Active)
            .IsRequired();


        entity.Property(e => e.Created)
            .IsUnicode(false);


        entity.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .IsUnicode(false);


        entity.Property(e => e.Updated)
            .IsUnicode(false);


        entity.Property(e => e.UpdatedBy)
            .HasMaxLength(50)
            .IsUnicode(false);

    });


    modelBuilder.Entity<WhatsAppMessage>(entity =>
    {   

        entity.ToTable("WhatsAppMessage", schema: "dbo");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .ValueGeneratedOnAdd();  // Indica que el Id es auto incremental

        entity.Property(e => e.Oui);

        entity.Property(e => e.PhoneTo)
            .HasMaxLength(20)
            .IsUnicode(true);

        entity.Property(e => e.TemplateNameUsed)
            .HasMaxLength(50)
            .IsUnicode(true);

        entity.Property(e => e.MessageBody)
            .HasMaxLength(3000)
            .IsUnicode(true);

        entity.Property(e => e.MessageId)
            .HasMaxLength(100)
            .IsUnicode(true);

        entity.Property(e => e.PhoneFrom)
            .HasMaxLength(20)
            .IsUnicode(true);

        entity.Property(e => e.PhoneId)
            .HasMaxLength(20)
            .IsUnicode(true);

        entity.Property(e => e.NotificationId);

        entity.Property(e => e.SendingAt);
        entity.Property(e => e.SendingDate);

        entity.Property(e => e.DeliveredAt);
        entity.Property(e => e.DeliveredDate);

        entity.Property(e => e.ReadedAt);
        entity.Property(e => e.ReadedDate);

        entity.Property(e => e.FailedAt);
        entity.Property(e => e.FailedDate);




        //Campos de control
        entity.Property(e => e.Created);



        entity.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.Property(e => e.Updated)
            .IsUnicode(false);


        entity.Property(e => e.UpdatedBy)
            .HasMaxLength(50)
            .IsUnicode(false);


        entity.Property(e => e.GcRecord)
            .IsUnicode(false);

    });



        base.OnModelCreating(modelBuilder);

    }

} 