using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        [Given(@"I have entered the url and logged into the portal")]
        public void GivenIHaveEnteredTheUrlAndLoggedIntoThePortal()
        {
            Thread.Sleep(2500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }
        
        [When(@"I clicked on delete button")]
        public void WhenIClickedOnDeleteButton()
        {
           
            //clicked on delete button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[3]/span[2]/i")).Click();
        }
        
        [Then(@"the language should be deleted from the table")]
        public void ThenTheLanguageShouldBeDeletedFromTheTable()
        {
            try
            {
                //start reports
                CommonMethods.ExtentReports();
                Thread.Sleep(2000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete language");
                Thread.Sleep(2000);
                String ExpectedText = "Tamil has been deleted from your languages";

                String alertText = Driver.driver.SwitchTo().Alert().Text;
                if (ExpectedText == alertText)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Language has been deleted successfully");
                }
            }


            catch
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed, language not deleted");

            }

            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[1]
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td[1]
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[1]

        }//*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i
         //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[2]/i
         //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td[3]/span[2]/i
         //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[3]/span[2]/i
    }
}
