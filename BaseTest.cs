using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumBasics;

public abstract class BaseTest
{
    protected IWebDriver Driver { get; private set; } = null!;

    [SetUp]
    public virtual void Setup()
    {
        Driver = new ChromeDriver();
    }

    [TearDown]
    public virtual void TearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}
