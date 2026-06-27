using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class WindowPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public WindowPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
    }

    public void ClickOpenNewWindow()
    {
        driver.FindElement(By.CssSelector(".example a")).Click();
    }

    public void SwitchToNewWindow(string originalHandle)
    {
        wait.Until(d => d.WindowHandles.Count > 1);
        foreach (var handle in driver.WindowHandles)
        {
            if (handle != originalHandle)
            {
                driver.SwitchTo().Window(handle);
                wait.Until(d => d.Title.Length > 0);
                return;
            }
        }
    }

    public void SwitchToOriginalWindow(string originalHandle)
    {
        driver.SwitchTo().Window(originalHandle);
    }

    public string GetCurrentPageTitle()
    {
        return driver.Title;
    }

    public string GetCurrentWindowHandle()
    {
        return driver.CurrentWindowHandle;
    }

    public int GetOpenWindowCount()
    {
        return driver.WindowHandles.Count;
    }
}
