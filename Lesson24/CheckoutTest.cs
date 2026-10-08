namespace Lesson24;


public class CheckoutTest : BaseTest
{
    [Test]
    public void Checkout()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login();
        Thread.Sleep(3000);
        AddToCartPage addToCartPage = new AddToCartPage(driver);
        addToCartPage.ClickAddToCartButton(); // добавить в корзину
        CartPage cartPage = new CartPage(driver);
        cartPage.ClickCartButton(); // перейти в корзину
        Thread.Sleep(3000);
        Assert.That(cartPage.YourCartDisplayed(), Is.True); // проверка что перешли в корзину
        Assert.That(cartPage.SelectedItem(), Is.True);
        Thread.Sleep(3000);
        CheckoutPage checkoutPage = cartPage.ClickCheckoutButton();
        checkoutPage.AddFirstName();
        checkoutPage.AddLastName();
        checkoutPage.AddZipCode();
        Thread.Sleep(3000);
        CheckoutOverviewPage checkoutOverviewPage = checkoutPage.ClickContinueButton();
        Thread.Sleep(3000);
        
        Assert.That(checkoutOverviewPage.IsItemDisplayed(), Is.True);
        Assert.That(checkoutOverviewPage.IsPriceDisplayed(), Is.True);
        Assert.That(checkoutOverviewPage.IsTaxDisplayed(), Is.True);
        Assert.That(checkoutOverviewPage.IsTotalPriceDisplayed(), Is.True);
        CheckoutCompletePage completePage = checkoutOverviewPage.ClickFinishButton();
        Thread.Sleep(3000);
        
        Assert.That(completePage.GetOrderCompleteText(), Is.EqualTo("Thank you for your order!"));
        Assert.That(completePage.IsDisplayedLabel(), Is.True);
        completePage.ClickGeneratePdfOrder();
        Thread.Sleep(3000);
        string downloadPath = @"C:\Users\petys\Downloads";
        string[] files = Directory.GetFiles(downloadPath, "swag-labs-order-*.pdf");
        Assert.That(files.Length, Is.GreaterThan(0));
        completePage.ClickBackHome();
        Thread.Sleep(3000);

    }
}