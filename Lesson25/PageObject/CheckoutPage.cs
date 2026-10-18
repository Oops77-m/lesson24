using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class CheckoutPage : BasePage
{
    [FindBy(How.Id, "first-name")]
    private BaseElement FirstName { get; set; }

    [FindBy(How.Id, "last-name")]
    private BaseElement LastName { get; set; }

    [FindBy(How.Id, "postal-code")]
    private BaseElement ZipCode { get; set; }

    [FindBy(How.Id, "continue")]
    private BaseElement ContinueButton { get; set; }

    public CheckoutPage(IWebDriver driver) : base(driver)
    {
    }
    public override bool IsLoaded()
    {
        return FirstName.IsDisplayed()
               && LastName.IsDisplayed()
               && ZipCode.IsDisplayed()
               && ContinueButton.IsDisplayed();
    }
    public CheckoutPage AddFirstName()
    {
        FirstName.SendKeys("Pashkova");
        return  this;
    }
    public CheckoutPage AddLastName()
    {
        LastName.SendKeys("Nastya");
        return  this;
    }

    public CheckoutPage AddZipCode()
    {
        ZipCode.SendKeys("1111");
        return  this;
    }

    public CheckoutOverviewPage ClickContinueButton()
    {
        ContinueButton.Click();
        return PageFactory.Create<CheckoutOverviewPage>(_driver);
    }
}