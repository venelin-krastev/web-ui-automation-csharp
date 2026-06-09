using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class ContextMenuPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public ContextMenuPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/context_menu");
    }

    public void RightClickHotspot()
    {
        var hotspot = wait.Until(d => d.FindElement(By.CssSelector("[id='hot-spot']")));
        var actions = new Actions(driver);
        actions.ContextClick(hotspot).Perform();
    }

    public string GetAlertText()
    {
        wait.Until(d => d.SwitchTo().Alert() != null);
        return driver.SwitchTo().Alert().Text;
    }

    public void AcceptAlert()
    {
        driver.SwitchTo().Alert().Accept();
    }
}
