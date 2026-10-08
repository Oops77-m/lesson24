using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson24;

public class LoginTests : BaseTest
{


    [Test] public void LoginSuccess()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductsPage  productsPage = loginPage.Login();
        
        //Assert.That(productsPage.GetUrl(), Does.Contain(expected: "main.py")); // берем урл и ищем там main.py
        //Assert.That(productsPage.GetPageTitle(),
        //expression: Is.EqualTo(expected: "ShareLane: Learn to Test"); // ищем текст
        //mainPage.Heander.метод
        Assert.That(productsPage.IsCartIconDisplayed(), Is.True);
        Thread.Sleep(3000);
        //driver.Navigate().Back(); //назад
        //Thread.Sleep(3000); // задержка на 3 сек
        //driver.Close(); // закрыть текущее окно
    }

    [Test]
    public void LoginLockedUser()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login(username: "locked_out_user");
        Thread.Sleep(3000);
        Assert.That(loginPage.GetErrorMessage(), 
            Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
}