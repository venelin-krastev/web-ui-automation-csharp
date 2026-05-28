using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class DynamicLoadingTests
{
    private IWebDriver driver;
    private DynamicLoadingPage dynamicLoadingPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        dynamicLoadingPage = new DynamicLoadingPage(driver);
    }

    [Test]
    public void Should_ShowHelloWorld_When_StartClickedOnExample1()
    {
        // Arrange
        dynamicLoadingPage.OpenExample1();

        // Act
        dynamicLoadingPage.ClickStart();

        // Assert
        Assert.That(dynamicLoadingPage.GetFinishText(), Does.Contain("Hello World!"),
            "Example 1 should show 'Hello World!' after loading completes");
    }

    [Test]
    public void Should_ShowHelloWorld_When_StartClickedOnExample2()
    {
        // Arrange
        dynamicLoadingPage.OpenExample2();

        // Act
        dynamicLoadingPage.ClickStart();

        // Assert
        Assert.That(dynamicLoadingPage.GetFinishText(), Does.Contain("Hello World!"),
            "Example 2 should show 'Hello World!' after loading completes");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
