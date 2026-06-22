using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class IFramePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public IFramePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
    }

    public void SwitchToIFrame()
    {
        var frame = wait.Until(d => d.FindElement(By.Id("mce_0_ifr")));
        driver.SwitchTo().Frame(frame);
    }

    public void SwitchToMainContent()
    {
        driver.SwitchTo().DefaultContent();
    }

    public void ClearAndTypeInEditor(string text)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript(
            $"document.getElementById('tinymce').innerHTML = '<p>{text}</p>';");
    }

    public string GetEditorText()
    {
        return (string?)((IJavaScriptExecutor)driver).ExecuteScript(
            "return document.getElementById('tinymce').innerText;") ?? string.Empty;
    }

    public string GetPageHeading()
    {
        return wait.Until(d => d.FindElement(By.CssSelector("h3"))).Text;
    }
}
