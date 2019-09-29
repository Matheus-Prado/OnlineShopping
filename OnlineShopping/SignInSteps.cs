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

        [Given(@"I am not logged in on the home page")]
        public void GivenIAmNotLoggedInOnTheHomePage()
        {
            Methods.OnlineStoreHomePage();

            //Verify if there's a user logged in
            if (Methods.existByClass("Log in to your customer account") == false)
                Methods.ClickByClass("logout");
        }
        
        [Given(@"I click to Sign In")]
        public void GivenIClickToSignIn()
        {
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
            Assert.IsTrue(Methods.existByClass("View my customer account"));
        }
        
        [Then(@"should appear the error message '(.*)'")]
        public void ThenShouldAppearTheErrorMessage(string p0)
        {
            //replacing line breakers with spaces
            Assert.AreEqual(Methods.MsgError().Replace("\r\n"," "), p0);
        }
    }
}
