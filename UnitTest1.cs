using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

public class Tests
{
    private IWebDriver driver;
    private GooglePage googlePage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        googlePage = new GooglePage(driver);
    }

    [Test]
    [Category("Smoke")]
    public void GoogleTitleIsCorrect()
    {
        googlePage.Open();
        Assert.That(googlePage.GetTitle(), Does.Contain("Google"));
    }

    [Test]
    public void GoogleSearchReturnsResults()
    {
        googlePage.Open();
        googlePage.Search("Selenium C#");
        Assert.That(driver.Title, Does.Contain("Selenium"));
    }

    [Test]
    [Ignore("Google consent banner breaks this test intermittently")]
    public void GoogleTitleStartsWithGoogle()
    {
        googlePage.Open();
        Assert.That(googlePage.GetTitle(), Does.StartWith("Google"));
    }

    [Test]
    public void GoogleSearchBoxIsVisible()
    {
        googlePage.Open();
        IWebElement searchBox = driver.FindElement(By.CssSelector("textarea[name='q']"));
        Assert.That(searchBox.Displayed, Is.True);
    }


    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
