using NUnit.Framework;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class DragAndDropTests : BaseTest
{
    private DragAndDropPage dragAndDropPage = null!;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        dragAndDropPage = new DragAndDropPage(Driver);
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
}
