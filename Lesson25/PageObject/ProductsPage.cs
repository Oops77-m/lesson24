using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class ProductsPage : BasePage
{
    
    [FindBy(How.CssSelector, "a[data-test='shopping-cart-link']")]
    private BaseElement CartIcon { get; set; }

    public HeanderSection Heander => PageFactory.Create<HeanderSection>(_driver);

    public ProductsPage(IWebDriver driver) : base(driver)
    {
      
    }
    public override bool IsLoaded()
    {
        return CartIcon.IsDisplayed();
    }
    public bool IsCartIconDisplayed()
    {
        return CartIcon.IsDisplayed();
    }
}