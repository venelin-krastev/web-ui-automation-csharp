using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class WindowTests
{
    private IWebDriver driver;
    private WindowPage windowPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        windowPage = new WindowPage(driver);
    }

    [Test]
    public void Should_OpenNewWindow_When_LinkClicked()
    {
        // Arrange
        windowPage.Open();

        // Act
        windowPage.ClickOpenNewWindow();

        // Assert
        Assert.That(windowPage.GetOpenWindowCount(), Is.EqualTo(2),
            "Clicking the link should open a second window");
    }

    [Test]
    public void Should_SwitchToNewWindow_When_NewWindowOpened()
    {
        // Arrange
        windowPage.Open();
        var originalHandle = windowPage.GetCurrentWindowHandle();

        // Act
        windowPage.ClickOpenNewWindow();
        windowPage.SwitchToNewWindow(originalHandle);

        // Assert
        Assert.That(windowPage.GetCurrentPageTitle(), Does.Contain("New Window"),
            "After switching to new window, title should contain 'New Window'");
    }

    [Test]
    public void Should_ReturnToOriginalWindow_When_SwitchedBack()
    {
        // Arrange
        windowPage.Open();
        var originalHandle = windowPage.GetCurrentWindowHandle();
        windowPage.ClickOpenNewWindow();
        windowPage.SwitchToNewWindow(originalHandle);

        // Act
        windowPage.SwitchToOriginalWindow(originalHandle);

        // Assert
        Assert.That(windowPage.GetCurrentPageTitle(), Does.Contain("The Internet"),
            "After switching back, should be on the original window");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
