using ACD.Domain.Models;
using ACD.Infrastructure.Context;
using ACD.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;




namespace ACD.Tests.DataAccess;




[TestFixture]
public class BalanceServiceProviderRepositoryTests
{


    private ACDDbContext _context;
    private Repository<BalanceServiceProvider> _repository;


    /// <summary>
    /// Sets up the test environment.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        //Configure the in-memory database
        var options = new DbContextOptionsBuilder<ACDDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ACDDbContext(options);

        // create a logger
        var logger = NullLogger<Repository<BalanceServiceProvider>>.Instance;

        _repository = new BalanceServiceProviderRepository(_context, logger);
    }


    /// <summary>
    /// Validates the GetAll method of the repository.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAll_ShouldReturnAllEntities()
    {
        // Arrange
        var balanceServiceProvider1 = new BalanceServiceProvider
        {
            BusinessId = "TestBusinessId",
            BspCode = "TestBspCode",
            BspName = "TestBspName",
            CodingScheme = "TestCodingScheme",
            Country = "TestCountry",
            ValidityStart = DateTime.Now,
            ValidityEnd = DateTime.Now.AddDays(1),
            Active = true
        };

        var balanceServiceProvider2 = new BalanceServiceProvider
        {
            BusinessId = "TestBusinessId2",
            BspCode = "TestBspCode2",
            BspName = "TestBspName2",
            CodingScheme = "TestCodingScheme2",
            Country = "TestCountry2",
            ValidityStart = DateTime.Now,
            ValidityEnd = DateTime.Now.AddDays(1),
            Active = true
        };
        await _repository.Add(balanceServiceProvider1);
        await _repository.Add(balanceServiceProvider2);

        // Act
        var allEntities = await _repository.GetAll();

        // Assert
        Assert.AreEqual(2, allEntities.Count);


    }

    /// <summary>
    /// Tests the Add method of the repository.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task Add_ShouldAddEntityToDatabase()
    {
        // Arrange
        var balanceServiceProvider = new BalanceServiceProvider
        {
            BusinessId = "TestBusinessId",
            BspCode = "TestBspCode",
            BspName = "TestBspName",
            CodingScheme = "TestCodingScheme",
            Country = "TestCountry",
            ValidityStart = DateTime.Now,
            ValidityEnd = DateTime.Now.AddDays(1),
            Active = true
        };

        // Act
        await _repository.Add(balanceServiceProvider);
        var addedEntity = await _context.BalanceServiceProviders.FindAsync(balanceServiceProvider.Id);

        // Assert
        Assert.IsNotNull(addedEntity);
        Assert.AreEqual(balanceServiceProvider.BusinessId, addedEntity.BusinessId);
        Assert.AreEqual(balanceServiceProvider.BspCode, addedEntity.BspCode);
        Assert.AreEqual(balanceServiceProvider.BspName, addedEntity.BspName);
        Assert.AreEqual(balanceServiceProvider.CodingScheme, addedEntity.CodingScheme);
        Assert.AreEqual(balanceServiceProvider.Country, addedEntity.Country);
        Assert.AreEqual(balanceServiceProvider.ValidityStart, addedEntity.ValidityStart);
        Assert.AreEqual(balanceServiceProvider.ValidityEnd, addedEntity.ValidityEnd);
        Assert.AreEqual(balanceServiceProvider.Active, addedEntity.Active);
    }

    
    /// <summary>
    /// Validates the GetById method of the repository.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task Remove_ShouldRemoveEntityFromDatabase()
    {
        // Arrange
        var balanceServiceProvider = new BalanceServiceProvider
        {
            BusinessId = "TestBusinessId",
            BspCode = "TestBspCode",
            BspName = "TestBspName",
            CodingScheme = "TestCodingScheme",
            Country = "TestCountry",
            ValidityStart = DateTime.Now,
            ValidityEnd = DateTime.Now.AddDays(1),
            Active = true
        };

        await _repository.Add(balanceServiceProvider);

        // Act
        await _repository.Remove(balanceServiceProvider);
        var removedEntity = await _context.BalanceServiceProviders.FindAsync(balanceServiceProvider.Id);

        // Assert
        Assert.IsNull(removedEntity);
    }


}