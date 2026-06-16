using NUnit.Framework;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class DropdownTests : BaseTest
{
    private DropdownPage dropdownPage = null!;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        dropdownPage = new DropdownPage(Driver);
    }

    [Test]
    public void SelectOptionOneByText()
    {
        dropdownPage.Open();
        dropdownPage.SelectByText("Option 1");
        Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo("Option 1"),
            "Selecting Option 1 by text should make it the selected option");
    }

    [Test]
    public void SelectOptionTwoByValue()
    {
        dropdownPage.Open();
        dropdownPage.SelectByValue("2");
        Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo("Option 2"),
            "Selecting by value '2' should select Option 2");
    }

    [TestCase("Option 1")]
    [TestCase("Option 2")]
    public void CanSelectOption(string option)
    {
        dropdownPage.Open();
        dropdownPage.SelectByText(option);
        Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo(option),
            $"Selected option should be {option}");
    }
}
