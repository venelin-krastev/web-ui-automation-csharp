using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class CheckboxPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public CheckboxPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
    }

    private IList<IWebElement> GetCheckboxes() =>
        wait.Until(d => d.FindElements(By.CssSelector("input[type='checkbox']")) is { Count: > 0 } els ? els : null)!;

    public void CheckCheckbox(int index)
    {
        var checkboxes = GetCheckboxes();
        if (!checkboxes[index].Selected)
            checkboxes[index].Click();
    }

    public void UncheckCheckbox(int index)
    {
        var checkboxes = GetCheckboxes();
        if (checkboxes[index].Selected)
            checkboxes[index].Click();
    }

    public bool IsChecked(int index) => GetCheckboxes()[index].Selected;
}
