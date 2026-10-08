using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;
/*
• !Открыть корзину. 
• !Проверить отображение страницы Cart.
• !Проверить отображение добавленного товара в корзине.
• !Проверить название товара в корзине.
• !Проверить количество товара.
• !Проверить цену товара.
• !Проверить удаление товара из корзины.
• !Проверить корзину после удаления товара.
• !Проверить переход к Checkout.
 */

public class CartPage : BasePage
{
    private readonly BaseElement _cartButton;
    private readonly BaseElement _titleCart;
    private readonly BaseElement _selectedItem;
    private readonly BaseElement _nameItem;
    private readonly BaseElement _items;
    private readonly BaseElement _priceItem;
    private readonly BaseElement _deleteItemButton;
    private readonly BaseElement _checkoutButton;
    private readonly BaseElement _firstName;

    public CartPage(IWebDriver driver) : base(driver)
    {
        _cartButton = new BaseElement(
            driver,
            By.CssSelector("a[data-test='shopping-cart-link']"));

        _titleCart = new BaseElement(
            driver,
            By.CssSelector("[data-test='title']"));

        _selectedItem = new BaseElement(
            driver,
            By.XPath("//div[contains(text(),'sleek, streamlined')]"));

        _nameItem = new BaseElement(
            driver,
            By.XPath("//div[text()='Sauce Labs Backpack']"));

        _items = new BaseElement(
            driver,
            By.CssSelector("[data-test='inventory-item']"));

        _priceItem = new BaseElement(
            driver,
            By.XPath("//div[text()='29.99']"));

        _deleteItemButton = new BaseElement(
            driver,
            By.Id("remove-sauce-labs-backpack"));
        _checkoutButton = new BaseElement(driver, By.Id("checkout"));

        _firstName = new BaseElement(
            driver,
            By.Id("first-name"));
    }

    public void ClickCartButton()
    {
        _cartButton.Click();
    }

    public bool YourCartDisplayed()
    {
        return _titleCart.IsDisplayed();
    }

    public bool SelectedItem()
    {
        return _selectedItem.IsDisplayed();
    }

    public bool NameItem()
    {
        return _nameItem.IsDisplayed();
    }

    public int CountItems()
    {
        return _items.Count();
    }

    public bool PriceItem()
    {
        return _priceItem.IsDisplayed();
    }

    public CartPage ClickDeleteItemButton()
    {
        _deleteItemButton.Click();
        return this;
    }
    public CheckoutPage ClickCheckoutButton()
    {
        _checkoutButton.Click();
        return new CheckoutPage(_driver);
    }
}