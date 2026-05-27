using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class DynamicLoadingPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public DynamicLoadingPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void OpenExample1()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
    }

    public void OpenExample2()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
    }

    public void ClickStart()
    {
        driver.FindElement(By.CssSelector("#start button")).Click();
    }

    public string GetFinishText()
    {
        wait.Until(d => d.FindElement(By.CssSelector("#finish h4")).Displayed);
        return driver.FindElement(By.CssSelector("#finish h4")).Text;
    }
}
