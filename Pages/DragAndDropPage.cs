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

        // DragAndDrop() uses HTML5 drag events which headless Chrome on Linux does not fire reliably.
        // ClickAndHold + MoveToElement + Release uses low-level mouse events that work cross-platform.
        new Actions(driver)
            .ClickAndHold(source)
            .MoveToElement(target)
            .Release()
            .Perform();
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
