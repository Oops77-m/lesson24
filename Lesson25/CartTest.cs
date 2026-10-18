using Allure.NUnit;
using Lesson25.Helpers;
using OpenQA.Selenium;

namespace Lesson25;

[AllureNUnit]
[TestFixture]
public class CartTest : BaseTest
{
    
    [Test]
    public void LoginSuccessForCart()
    {
        LoginPage loginPage = PageFactory.Create<LoginPage>(driver);
        ProductsPage  productsPage = loginPage.Login();
        productsPage.WaitUntilLoaded();
        PageFactory.Create<AddToCartPage>(driver)
            .ClickAddToCartButton(); // добавить в корзину
        CartPage cartPage = PageFactory.Create<CartPage>(driver);
        cartPage.ClickCartButton(); // перейти в корзину
        cartPage.WaitUntilLoaded();
        Assert.That(cartPage.YourCartDisplayed(), Is.True); // проверка что перешли в корзину
        Assert.That(cartPage.SelectedItem(), Is.True);  // проверка что товар в корзине
        Assert.That(cartPage.NameItem(), Is.True);  // проверка имени товара
        Assert.That(cartPage.CountItems(), Is.EqualTo(1)); //считаем товары в корзине
        Assert.That(cartPage.PriceItem(), Is.True); // проверяем цену
        cartPage.ClickDeleteItemButton(); // удалить из корзины
        Assert.That(cartPage.CountItems(), Is.EqualTo(0));// проверить что товар удален
        CheckoutPage checkoutPage = cartPage.ClickCheckoutButton();
        
    }
}