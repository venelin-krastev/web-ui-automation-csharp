using NUnit.Framework;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class ContextMenuTests : BaseTest
{
    private ContextMenuPage contextMenuPage = null!;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        contextMenuPage = new ContextMenuPage(Driver);
    }

    [Test]
    public void Should_ShowAlert_When_HotspotRightClicked()
    {
        // Arrange
        contextMenuPage.Open();

        // Act
        contextMenuPage.RightClickHotspot();

        // Assert
        Assert.That(contextMenuPage.GetAlertText(), Does.Contain("You selected a context menu"),
            "Right clicking the hotspot should trigger an alert with context menu message");
    }

    [Test]
    public void Should_DismissAlert_When_AlertAccepted()
    {
        // Arrange
        contextMenuPage.Open();
        contextMenuPage.RightClickHotspot();
        contextMenuPage.GetAlertText();

        // Act
        contextMenuPage.AcceptAlert();

        // Assert
        Assert.That(Driver.WindowHandles.Count, Is.EqualTo(1),
            "After accepting alert, browser should return to normal state");
    }
}
