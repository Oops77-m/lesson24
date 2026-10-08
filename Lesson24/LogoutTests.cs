
namespace Lesson24;

[TestFixture]
public class LogoutTests : BaseTest
{
    [Test]
    public void LoginSuccess()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductsPage productsPage = loginPage.Login();
        var newLoginPage = productsPage.Heander.Logout();
        Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True);
    }
}