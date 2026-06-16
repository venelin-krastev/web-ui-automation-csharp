using NUnit.Framework;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class LoginTests : BaseTest
{
    private LoginPage loginPage = null!;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        loginPage = new LoginPage(Driver);
    }

    [Test]
    public void Should_RedirectToSecurePage_When_ValidCredentialsEntered()
    {
        // Arrange
        loginPage.Open();

        // Act
        loginPage.Login("tomsmith", "SuperSecretPassword!");

        // Assert
        Assert.That(Driver.Url, Does.Contain("/secure"),
            "Successful login should redirect to /secure");
    }

    [Test]
    public void Should_ShowSuccessFlashMessage_When_ValidCredentialsEntered()
    {
        // Arrange
        loginPage.Open();

        // Act
        loginPage.Login("tomsmith", "SuperSecretPassword!");

        // Assert
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("You logged into a secure area!"),
            "Successful login should show success flash message");
    }

    [Test]
    public void Should_ShowInvalidPasswordError_When_WrongPasswordEntered()
    {
        // Arrange
        loginPage.Open();

        // Act
        loginPage.Login("tomsmith", "wrongpassword");

        // Assert
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("Your password is invalid!"),
            "Wrong password should show error flash message");
    }

    [Test]
    public void Should_ShowInvalidUsernameError_When_WrongUsernameEntered()
    {
        // Arrange
        loginPage.Open();

        // Act
        loginPage.Login("wronguser", "SuperSecretPassword!");

        // Assert
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("Your username is invalid!"),
            "Wrong username should show error flash message");
    }
}
