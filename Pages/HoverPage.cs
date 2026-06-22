using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class HoverPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public HoverPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
    }

    private IList<IWebElement> GetAvatars() =>
        wait.Until(d => d.FindElements(By.CssSelector(".figure")) is { Count: > 0 } els ? els : null)!;

    public void HoverOverAvatar(int index)
    {
        var avatars = GetAvatars();
        var actions = new Actions(driver);
        actions.MoveToElement(avatars[index]).Perform();
    }

    public string GetAvatarCaption(int index)
    {
        var avatars = GetAvatars();
        wait.Until(d => avatars[index].FindElement(By.CssSelector(".figcaption")).Displayed);
        return avatars[index].FindElement(By.CssSelector(".figcaption h5")).Text;
    }
}
