using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;
using System.Threading;

namespace OnlineShopping
{
    public class GeneralMethods
    {
        private IWebDriver driver;

        decimal itemPrice;
        decimal totalItemPrice;
        decimal totalPrice;

        public void startSettings()
        {
            driver = new ChromeDriver(@"C:\ChromeDrive");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        public void wait(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }

        public void OnlineStoreHomePage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void shoppingCartSummary()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=order");
        }

        public void ClickByClass(string _class)
        {
            driver.FindElement(By.ClassName(_class)).Click();
        }

        public void ClickById(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            
        }

        public void clickByXpath(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }

        public void ClickByText(string text)
        {
            driver.FindElement(By.LinkText(text)).Click();
        }

        public bool existInPage(string text)
        {
            return driver.PageSource.Contains(text);
        }

        public void SingInCredentials(string email, string password)
        {
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
        }

        public string msgError()
        {
            return driver.FindElement(By.XPath("//*[@class='alert alert-danger']")).Text;
        }

        public string msgAlert()
        {
            return driver.FindElement(By.XPath("//*[@class='alert alert-warning']")).Text;
        }

        public void mouseoverByXpath(string xpath)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath(xpath))).Perform();
        }
        public void mouseoverById(string id)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.Id(id))).Perform();
        }

        public void PricesBeforeChange()
        {
            itemPrice = Convert.ToDecimal(driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[4]/span")).Text.Replace("$",""));
            totalItemPrice = Convert.ToDecimal(driver.FindElement(By.Id("total_product")).Text.Replace("$", ""));
            totalPrice = Convert.ToDecimal(driver.FindElement(By.Id("total_price")).Text.Replace("$", ""));
        }

        public void addTotalProductPrice()
        {
            totalItemPrice = totalItemPrice + itemPrice;
        }

        public void addTotalPrice()
        {
            totalPrice = totalPrice + itemPrice;
        }

        public decimal totalProductValue()
        {
            return totalItemPrice;
        }

        public decimal totalValue()
        {
            return totalPrice;
        }

        public string textById(string id)
        {
            return driver.FindElement(By.Id(id)).Text;
        }

        public void switchToQuickViewFrame()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.ClassName("fancybox-iframe")));
            Thread.Sleep(2000);
        }

        public void switchToNewBrowserWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            
        }

        public void switchToFirstBrowserWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());

        }
    }
}
