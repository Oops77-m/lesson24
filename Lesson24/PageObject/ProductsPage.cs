using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;

public class ProductsPage : BasePage
{
    private readonly BaseElement _cartIcon;

    public HeanderSection Heander => new HeanderSection(_driver);

    public ProductsPage(IWebDriver driver) : base(driver)
    {
        _cartIcon = new BaseElement(
            driver,
            By.CssSelector("a[data-test='shopping-cart-link']"));
    }

    public bool IsCartIconDisplayed()
    {
        return _cartIcon.IsDisplayed();
    }
}