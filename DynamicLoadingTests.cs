using NUnit.Framework;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class DynamicLoadingTests : BaseTest
{
    private DynamicLoadingPage dynamicLoadingPage = null!;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        dynamicLoadingPage = new DynamicLoadingPage(Driver);
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
}
