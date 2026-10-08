using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;

public class CheckoutPage : BasePage
{
    
    private readonly BaseElement _firstName;
    private readonly BaseElement _lastName;
    private readonly BaseElement _zipCode;
    private readonly BaseElement _continueButton;

    public CheckoutPage(IWebDriver driver) : base(driver)
    {
        _firstName = new BaseElement(driver, By.Id("first-name"));
        _lastName = new BaseElement(driver, By.Id("last-name"));
        _zipCode = new BaseElement(driver, By.Id("postal-code"));
        _continueButton = new BaseElement(driver, By.Id("continue"));
    }

    public CheckoutPage AddFirstName()
    {
        _firstName.SendKeys("Pashkova");
        return  this;
    }
    public CheckoutPage AddLastName()
    {
        _lastName.SendKeys("Nastya");
        return  this;
    }

    public CheckoutPage AddZipCode()
    {
        _zipCode.SendKeys("1111");
        return  this;
    }

    public CheckoutOverviewPage ClickContinueButton()
    {
        _continueButton.Click();
        return new CheckoutOverviewPage(_driver);
    }
}