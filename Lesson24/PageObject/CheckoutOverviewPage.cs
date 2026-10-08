using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;

public class CheckoutOverviewPage : BasePage
{
    private readonly BaseElement _item;
    private readonly BaseElement _price;
    private readonly BaseElement _tax;
    private readonly BaseElement _totalPrice;
    private readonly BaseElement _finishButton;

    public CheckoutOverviewPage(IWebDriver driver) : base(driver)
    {
        _item = new BaseElement(driver, By.CssSelector("[data-test='inventory-item-name']")); 
        _price = new BaseElement(driver, By.CssSelector("[data-test='inventory-item-price']"));
        _tax = new BaseElement(driver, By.CssSelector("[data-test='tax-label']"));
        _totalPrice = new BaseElement(driver, By.CssSelector("[data-test='total-label']"));
        _finishButton = new BaseElement(driver, By.Id("finish"));
    }
    public bool IsItemDisplayed()
    {
        return _item.IsDisplayed();
    }

    public bool IsPriceDisplayed()
    {
        return _price.IsDisplayed();
    }

    public bool IsTaxDisplayed()
    {
        return _tax.IsDisplayed();
    }

    public bool IsTotalPriceDisplayed()
    {
        return _totalPrice.IsDisplayed();
    }
    public CheckoutCompletePage ClickFinishButton()
    {
        _finishButton.Click();
        return new CheckoutCompletePage(_driver);
    }
}