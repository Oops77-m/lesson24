using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class CartPage : BasePage
{
    [FindBy(How.CssSelector, "a[data-test='shopping-cart-link']")]
    private BaseElement CartButton { get; set; }

    [FindBy(How.CssSelector, "[data-test='title']")]
    private BaseElement TitleCart { get; set; }

    [FindBy(How.XPath, "//div[contains(text(),'sleek, streamlined')]")]
    private BaseElement SelectedItemElement { get; set; }

    [FindBy(How.XPath, "//div[text()='Sauce Labs Backpack']")]
    private BaseElement NameItemElement { get; set; }

    [FindBy(How.CssSelector, "[data-test='inventory-item']")]
    private BaseElement Items { get; set; }

    [FindBy(How.XPath, "//div[text()='29.99']")]
    private BaseElement PriceItemElement { get; set; }

    [FindBy(How.Id, "remove-sauce-labs-backpack")]
    private BaseElement DeleteItemButton { get; set; }

    [FindBy(How.Id, "checkout")]
    private BaseElement CheckoutButton { get; set; }

    public CartPage(IWebDriver driver) : base(driver)
    {
       
    }
    public override bool IsLoaded()
    {
        return TitleCart.IsDisplayed()
               && CheckoutButton.IsDisplayed();
    }

    public void ClickCartButton()
    {
        CartButton.Click();
    }

    public bool YourCartDisplayed()
    {
        return TitleCart.IsDisplayed();
    }

    public bool SelectedItem()
    {
        return SelectedItemElement.IsDisplayed();
    }

    public bool NameItem()
    {
        return NameItemElement.IsDisplayed();
    }

    public int CountItems()
    {
        return Items.Count();
    }

    public bool PriceItem()
    {
        return PriceItemElement.IsDisplayed();
    }

    public CartPage ClickDeleteItemButton()
    {
        DeleteItemButton.Click();
        return this;
    }
    public CheckoutPage ClickCheckoutButton()
    {
        CheckoutButton.Click();
        return PageFactory.Create<CheckoutPage>(_driver);
    }
}