using ACD.Domain.Models;
using NUnit.Framework;

namespace ACD.Tests.ModelValidations;



/// <summary>
/// Tests for the BalanceServiceProviderAttribute class.
/// </summary>
[TestFixture]
public class BalanceServiceProviderAttributeTests
{

    /// <summary>
    /// Validates that the BusinessId property is set correctly.
    /// </summary>
    [Test]
    public void BspName_Set_Get_ReturnsCorrectValue()
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
        var expectedName = "TestBspName";

        // Act
        var actualName = balanceServiceProvider.BspName;

        // Assert
        NUnit.Framework.Assert.AreEqual(expectedName, actualName);

    }


    /// <summary>
    /// Validates that the BspCode property is set correctly.
    /// </summary>
    [Test]
    public void BspCode_ShouldNotBeNullOrEmpty()
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
        var actualBspCode = balanceServiceProvider.BspCode;

        // Assert
        Assert.IsNotEmpty(actualBspCode);
    }



}