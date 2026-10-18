using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class AddToCartPage : BasePage
{
    [FindBy(How.Id, "add-to-cart-sauce-labs-backpack")]
    private BaseElement AddToCartButton { get; set; }

    public AddToCartPage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsLoaded()
    {
        return AddToCartButton.IsDisplayed();
    }

    public AddToCartPage ClickAddToCartButton()
    {
        AddToCartButton.Click();
        return this;
    }
}