using OpenQA.Selenium;

namespace Lesson24;


public class CartTest : BaseTest
{
    [Test]
    public void LoginSuccessForCart()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductsPage  productsPage = loginPage.Login();
        //Assert.That(productsPage.IsCartIconDisplayed(), Is.True);
        Thread.Sleep(3000);
        AddToCartPage addToCartPage = new AddToCartPage(driver);
        addToCartPage.ClickAddToCartButton(); // добавить в корзину
        CartPage cartPage = new CartPage(driver);
        cartPage.ClickCartButton(); // перейти в корзину
        Thread.Sleep(3000);
        Assert.That(cartPage.YourCartDisplayed(), Is.True); // проверка что перешли в корзину
        Assert.That(cartPage.SelectedItem(), Is.True);  // проверка что товар в корзине
        Assert.That(cartPage.NameItem(), Is.True);  // проверка имени товара
        Assert.That(cartPage.CountItems(), Is.EqualTo(1)); //считаем товары в корзине
        Assert.That(cartPage.PriceItem(), Is.True); // проверяем цену
        cartPage.ClickDeleteItemButton(); // удалить из корзины
        Thread.Sleep(3000);
        Assert.That(cartPage.CountItems(), Is.EqualTo(0));// проверить что товар удален
        cartPage.ClickCheckoutButton();
        Thread.Sleep(3000);
        //Assert.That(cartPage.ClickCheckoutButton(), Is.True); // проверяем что перешли на страницу чекаут
    }
}