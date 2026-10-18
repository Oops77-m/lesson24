using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class CheckoutCompletePage : BasePage
{
    //[FindBy(How.CssSelector, "[data-test='pony-express']")]
    //private BaseElement Label { get; set; }

    [FindBy(How.CssSelector, "[data-test='complete-header']")]
    private BaseElement CompleteHeader { get; set; }

    [FindBy(How.Id, "generate-pdf-order")]
    private BaseElement ButtonGeneratePdfOrder { get; set; }

    [FindBy(How.Id, "back-to-products")]
    private BaseElement ButtonBackHome { get; set; }

    public CheckoutCompletePage(IWebDriver driver) : base(driver)
    {
    }
    public override bool IsLoaded()
    {
        return CompleteHeader.IsDisplayed()
               && ButtonBackHome.IsDisplayed();
    }

    //public bool IsDisplayedLabel()
    //{
    //    return Label.IsDisplayed();
    //}
    public string GetOrderCompleteText()
    {
        return CompleteHeader.GetText();
    }
    public void ClickGeneratePdfOrder()
    {
        ButtonGeneratePdfOrder.Click();
    }
    public void ClickBackHome()
    {
        ButtonBackHome.Click();
    }
}