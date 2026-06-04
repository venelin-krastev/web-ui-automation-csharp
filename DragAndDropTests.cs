using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class DragAndDropTests
{
    private IWebDriver driver;
    private DragAndDropPage dragAndDropPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        dragAndDropPage = new DragAndDropPage(driver);
    }

    [Test]
    public void Should_SwapColumns_When_ColumnADraggedToColumnB()
    {
        // Arrange
        dragAndDropPage.Open();

        // Act
        dragAndDropPage.DragAToB();

        // Assert
        Assert.That(dragAndDropPage.GetColumnAHeader(), Is.EqualTo("B"),
            "Column A should display 'B' after drag and drop");
        Assert.That(dragAndDropPage.GetColumnBHeader(), Is.EqualTo("A"),
            "Column B should display 'A' after drag and drop");
    }

    [Test]
    public void Should_HaveCorrectInitialState_When_PageLoads()
    {
        // Arrange & Act
        dragAndDropPage.Open();

        // Assert
        Assert.That(dragAndDropPage.GetColumnAHeader(), Is.EqualTo("A"),
            "Column A should display 'A' on page load");
        Assert.That(dragAndDropPage.GetColumnBHeader(), Is.EqualTo("B"),
            "Column B should display 'B' on page load");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
