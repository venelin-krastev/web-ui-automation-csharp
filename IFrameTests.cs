using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class IFrameTests
{
    private IWebDriver driver;
    private IFramePage iFramePage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        iFramePage = new IFramePage(driver);
    }

    [Test]
    public void Should_TypeText_When_InsideIFrame()
    {
        // Arrange
        iFramePage.Open();
        iFramePage.SwitchToIFrame();

        // Act
        iFramePage.ClearAndTypeInEditor("Hello IFrame");

        // Assert
        Assert.That(iFramePage.GetEditorText(), Is.EqualTo("Hello IFrame"),
            "Text typed inside IFrame should be retrievable");
    }

    [Test]
    public void Should_AccessMainContent_When_SwitchedBackFromIFrame()
    {
        // Arrange
        iFramePage.Open();
        iFramePage.SwitchToIFrame();
        iFramePage.ClearAndTypeInEditor("Test");

        // Act
        iFramePage.SwitchToMainContent();

        // Assert
        Assert.That(iFramePage.GetPageHeading(), Does.Contain("An iFrame"),
            "After switching back to main content, page heading should be accessible");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
