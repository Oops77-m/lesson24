using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;

public class AddToCartPage
{
    private readonly BaseElement _addToCartButton;

    public AddToCartPage(IWebDriver driver)
    {
        _addToCartButton = new BaseElement(
            driver,
            By.Id("add-to-cart-sauce-labs-backpack"));
    }

    public AddToCartPage ClickAddToCartButton()
    {
        _addToCartButton.Click();
        return this;
    }
}