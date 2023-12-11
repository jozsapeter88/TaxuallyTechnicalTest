using Microsoft.AspNetCore.Mvc;
using Moq;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests;

public class VatRegistrationControllerTests
{
    [Fact]
    public async Task Post_UK_Success()
    {
        // Arrange
        var request = new VatRegistrationRequest { CompanyName = "TestUKCompany", CompanyId = "1", Country = "GB" };

        var vatRegistrationStrategyMock = new Mock<IVatRegistrationStrategy>();
        var controller = new VatRegistrationController(vatRegistrationStrategyMock.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<OkResult>(result);
        vatRegistrationStrategyMock.Verify(strategy => strategy.RegisterAsync(request), Times.Once);
    }

    [Fact]
    public async Task Post_France_Success()
    {
        // Arrange
        var request = new VatRegistrationRequest { CompanyName = "TestFrenchCompany", CompanyId = "2", Country = "FR" };

        var vatRegistrationStrategyMock = new Mock<IVatRegistrationStrategy>();
        var controller = new VatRegistrationController(vatRegistrationStrategyMock.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<OkResult>(result);
        vatRegistrationStrategyMock.Verify(strategy => strategy.RegisterAsync(request), Times.Once);
    }

    [Fact]
    public async Task Post_Germany_Success()
    {
        // Arrange
        var request = new VatRegistrationRequest { CompanyName = "TestGermanCompany", CompanyId = "3", Country = "DE" };

        var vatRegistrationStrategyMock = new Mock<IVatRegistrationStrategy>();
        var controller = new VatRegistrationController(vatRegistrationStrategyMock.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<OkResult>(result);
        vatRegistrationStrategyMock.Verify(strategy => strategy.RegisterAsync(request), Times.Once);
    }
}