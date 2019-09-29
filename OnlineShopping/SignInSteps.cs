using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace OnlineShopping
{
    [Binding]
    public class SignInSteps
    {
        static GeneralMethods Methods = new GeneralMethods();

        [BeforeFeature]
        public static void Start()
        {
            Methods.startSettings();
        }

        [AfterFeature]
        public static void Close()
        {
            Methods.CloseBrowser();
        }

        //Sign In feature steps
        #region SignIN Steps
        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            Methods.OnlineStoreHomePage();
        }
        
        [Given(@"I click to Sign In")]
        public void GivenIClickToSignIn()
        {
            //Verify if the user is already logged in
            if (Methods.existInPage("Log in to your customer account") == false)
                Methods.ClickByClass("logout");

            Methods.ClickByClass("login");
        }
        
        [When(@"I enter my email and password")]
        public void WhenIEnterMyEmailAndPassword(Table table)
        {
            var credentials = table.CreateInstance<Credentials>();
            Methods.SingInCredentials(credentials.email, credentials.password);
        }
        
        [When(@"I click Sign In")]
        public void WhenIClickSignIn()
        {
            Methods.ClickById("SubmitLogin");
        }
        
        [Then(@"My username should appear where the sign in button was")]
        public void ThenMyUsernameShouldAppearWhereTheSignInButtonWas()
        {
            Assert.IsTrue(Methods.existInPage("View my customer account"));
        }
        
        [Then(@"should appear the error message '(.*)'")]
        public void ThenShouldAppearTheErrorMessage(string errorMessage)
        {
            //replacing line breakers with spaces
            Assert.AreEqual(Methods.msgError().Replace("\r\n"," "), errorMessage);
        }
        #endregion

        //Cart feature steps
        #region Cart Steps
        [Given(@"I am on the shopping-cart summary")]
        public void GivenIAmOnTheShopping_CartSummary()
        {
            Methods.shoppingCartSummary();
        }

        [Given(@"there is a iten on my cart")]
        public void GivenThereIsAItenOnMyCart()
        {
            //Verify if there is a item in the cart and adding one if there is not
            if (Methods.existInPage("cart_summary") == false)
            {
                Methods.OnlineStoreHomePage();
                Methods.mouseoverByXpath("//img[@title='Blouse']");
                Methods.ClickByText("Add to cart");
                Methods.ClickByText("Proceed to checkout");
            }
        }

        [Given(@"I select an item to '(.*)'")]
        public void GivenISelectAnItemTo(string linkText)
        {
            Methods.mouseoverByXpath("//img[@title='Blouse']");
            Methods.ClickByText(linkText);
        }

        [When(@"click to '(.*)'")]
        public void WhenClickTo(string linkText)
        {
            Methods.ClickByText(linkText);
        }

        [When(@"I increase the quantity of the item")]
        public void WhenIIncreaseTheQuantityOfTheItem()
        {
            //getting the prices to compare to the new ones whem number of items change
            Methods.PricesBeforeChange();
            Methods.clickByXpath(" / html / body / div / div[2] / div / div[3] / div / div[2] / table / tbody / tr[1] / td[5] / div / a[2]");
            Methods.wait(2000);
            //Adding the price of the product
            Methods.addTotalProductPrice();
            Methods.addTotalPrice();
        }

        [When(@"I remove all items from my cart")]
        public void WhenIRemoveAllItemsFromMyCart()
        {
            while (Methods.existInPage("cart_summary") == true)
            {
                Methods.ClickByClass("icon-trash");
                Methods.wait(3000);
            }
        }

        [Then(@"the site send me to the shopping-cart summary page")]
        public void ThenTheSiteSendMeToTheShopping_CartSummaryPage()
        {
            Assert.IsTrue(Methods.existInPage("cart_title"));
        }

        [Then(@"the item should be on my cart")]
        public void ThenTheItemShouldBeOnMyCart()
        {
            Assert.IsTrue(Methods.existInPage("product_2_7_0_0"));
        }

        [Then(@"the total products price should change")]
        public void ThenTheTotalProductsPriceShouldChange()
        {
            Assert.AreEqual(Methods.totalProductValue(), Convert.ToDecimal(Methods.textById("total_product").Replace("$","")));
            
        }

        [Then(@"the total price should change")]
        public void ThenTheTotalPriceShouldChange()
        {
            Assert.AreEqual(Methods.totalValue(), Convert.ToDecimal(Methods.textById("total_price").Replace("$", "")));
        }

        [Then(@"should appear the message '(.*)'")]
        public void ThenShouldAppearTheMessage(string alertMessage)
        {
            //replacing line breakers with spaces
            Assert.AreEqual(Methods.msgAlert().Replace("\r\n", " "), alertMessage);
        }
        #endregion

        //Quick View feature steps
        #region Quick View
        [When(@"the site open the quick view page")]
        public void WhenTheSiteOpenTheQuickViewPage()
        {
            Assert.IsTrue(Methods.existInPage("fancybox-skin"));
            Methods.switchToQuickViewFrame();
        }

        [Then(@"It should display a description")]
        public void ThenItShouldDisplayADescription()
        {
            Assert.IsNotEmpty(Methods.textById("short_description_content"));
        }

        [When(@"I pass the mouse over one of the small images")]
        public void WhenIPassTheMouseOverOneOfTheSmallImages()
        {
            Methods.mouseoverById("thumb_6");
        }

        [Then(@"the image displayed should change")]
        public void ThenTheImageDisplayedShouldChange()
        {
            Assert.IsTrue(Methods.existInPage("http://automationpractice.com/img/p/6/6-large_default.jpg"));
        }

        [When(@"I click to share the product on twitter")]
        public void WhenIClickToShareTheProductOnTwitter()
        {
            Methods.clickByXpath("//*[@id='product']/div/div/div[2]/p[7]/button[1]");
        }

        [Then(@"a pop-up of twitter with a text to tweet should appear")]
        public void ThenAPop_UpOfTwitterWithATextToTweetShouldAppear()
        {
            Methods.switchToNewBrowserWindow();
            Assert.IsNotEmpty(Methods.textById("status"));
            Methods.CloseBrowser();
            Methods.switchToFirstBrowserWindow();
        }

        #endregion
    }
}
