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


        base.OnModelCreating(modelBuilder);

    }

} 