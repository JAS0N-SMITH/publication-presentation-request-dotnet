using Bunit;
using Xunit;
using Frontend.Pages;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bunit.TestDoubles;
using Moq;
using Moq.Protected;
using Microsoft.Extensions.DependencyInjection;

namespace Frontend.Tests;

public class CounterTests
{
    [Fact]
    public void CounterComponent_ShouldIncrementCounter_WhenButtonClicked()
    {
        // Arrange
        using var context = new TestContext();
        var component = context.RenderComponent<Counter>();

        // Act
        component.Find("button").Click();

        // Assert
        Assert.Contains("Current count: 1", component.Markup);
    }
}

// Updated Home test to match actual content
public class HomeTests
{
    [Fact]
    public void HomeComponent_ShouldRenderCorrectly()
    {
        // Arrange
        using var context = new TestContext();
        var component = context.RenderComponent<Home>();

        // Assert
        Assert.Contains("Hello, world!", component.Markup);
    }
}

// Adjusted Weather test to use TestContext.Services for HttpClient registration
public class WeatherTests
{
    [Fact]
    public void WeatherComponent_ShouldDisplayWeatherData()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("[{\"Date\":\"2025-04-13\",\"TemperatureC\":25,\"Summary\":\"Sunny\"}]")
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("http://localhost")
        };

        using var context = new TestContext();
        context.Services.Add(new ServiceDescriptor(typeof(HttpClient), httpClient));

        var component = context.RenderComponent<Weather>();

        // Assert
        Assert.Contains("Sunny", component.Markup);
    }
}
