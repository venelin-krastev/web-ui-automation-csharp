using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class DragAndDropPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public DragAndDropPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
    }

    public void DragAToB()
    {
        var source = wait.Until(d => d.FindElement(By.Id("column-a")));
        var target = wait.Until(d => d.FindElement(By.Id("column-b")));
        var actions = new Actions(driver);
        actions.DragAndDrop(source, target).Perform();
    }

    public string GetColumnAHeader()
    {
        return driver.FindElement(By.CssSelector("#column-a header")).Text;
    }

    public string GetColumnBHeader()
    {
        return driver.FindElement(By.CssSelector("#column-b header")).Text;
    }
}
