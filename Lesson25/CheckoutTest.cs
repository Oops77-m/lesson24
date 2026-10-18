using Allure.NUnit;
using Lesson25.Helpers;

namespace Lesson25;

[AllureNUnit]
[TestFixture]
public class CheckoutTest : BaseTest
{
    [Test]
    public void Checkout()
    {
        LoginPage loginPage = PageFactory.Create<LoginPage>(driver);
        ProductsPage productsPage = loginPage.Login();
        productsPage.WaitUntilLoaded();
        
        PageFactory.Create<AddToCartPage>(driver)
            .ClickAddToCartButton(); // добавить в корзину
        
        CartPage cartPage = PageFactory.Create<CartPage>(driver);
        cartPage.ClickCartButton(); // перейти в корзину
        cartPage.WaitUntilLoaded();
        
        Assert.That(cartPage.YourCartDisplayed(), Is.True); // проверка что перешли в корзину
        Assert.That(cartPage.SelectedItem(), Is.True);
        
        CheckoutPage checkoutPage = cartPage.ClickCheckoutButton();
        checkoutPage.AddFirstName();
        checkoutPage.AddLastName();
        checkoutPage.AddZipCode();
        
        CheckoutOverviewPage checkoutOverviewPage = checkoutPage.ClickContinueButton();
        checkoutOverviewPage.WaitUntilLoaded();
        
        Assert.That(checkoutOverviewPage.IsItemDisplayed(), Is.True);
        Assert.That(checkoutOverviewPage.IsPriceDisplayed(), Is.True);
        Assert.That(checkoutOverviewPage.IsTaxDisplayed(), Is.True);
        Assert.That(checkoutOverviewPage.IsTotalPriceDisplayed(), Is.True);
        
        CheckoutCompletePage completePage = checkoutOverviewPage.ClickFinishButton();
        completePage.WaitUntilLoaded();
        
        Assert.That(completePage.GetOrderCompleteText(), Is.EqualTo("Thank you for your order!"));
        completePage.ClickGeneratePdfOrder();
        completePage.WaitUntilLoaded();
        string downloadPath = @"C:\Users\petys\Downloads";
        string[] files = Directory.GetFiles(downloadPath, "swag-labs-order-*.pdf");
        Assert.That(files.Length, Is.GreaterThan(0));
        completePage.ClickBackHome();
    }
}