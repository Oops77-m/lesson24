using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class CheckoutOverviewPage : BasePage
{
    [FindBy(How.CssSelector, "[data-test='inventory-item-name']")]
    private BaseElement Item { get; set; }

    [FindBy(How.CssSelector, "[data-test='inventory-item-price']")]
    private BaseElement Price { get; set; }

    [FindBy(How.CssSelector, "[data-test='tax-label']")]
    private BaseElement Tax { get; set; }

    [FindBy(How.CssSelector, "[data-test='total-label']")]
    private BaseElement TotalPrice { get; set; }

    [FindBy(How.Id, "finish")]
    private BaseElement FinishButton { get; set; }

    public CheckoutOverviewPage(IWebDriver driver) : base(driver)
    {
    }
    public override bool IsLoaded()
    {
        return Item.IsDisplayed()
               && Price.IsDisplayed()
               && Tax.IsDisplayed()
               && TotalPrice.IsDisplayed()
               && FinishButton.IsDisplayed();
    }
    public bool IsItemDisplayed()
    {
        return Item.IsDisplayed();
    }

    public bool IsPriceDisplayed()
    {
        return Price.IsDisplayed();
    }

    public bool IsTaxDisplayed()
    {
        return Tax.IsDisplayed();
    }

    public bool IsTotalPriceDisplayed()
    {
        return TotalPrice.IsDisplayed();
    }
    public CheckoutCompletePage ClickFinishButton()
    {
        FinishButton.Click();
        return PageFactory.Create<CheckoutCompletePage>(_driver);
    }
}