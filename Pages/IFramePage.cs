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
        var body = wait.Until(d => d.FindElement(By.Id("tinymce")));
        body.Clear();
        body.SendKeys(text);
    }

    public string GetEditorText()
    {
        var body = wait.Until(d => d.FindElement(By.Id("tinymce")));
        return body.Text;
    }

    public string GetPageHeading()
    {
        return wait.Until(d => d.FindElement(By.CssSelector("h3"))).Text;
    }
}
