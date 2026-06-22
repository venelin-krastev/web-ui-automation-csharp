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
        var options = new ChromeOptions();
        if (Environment.GetEnvironmentVariable("CI") == "true")
        {
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }
        Driver = new ChromeDriver(options);
    }

    [TearDown]
    public virtual void TearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}
