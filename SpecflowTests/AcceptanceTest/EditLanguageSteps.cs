using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace specflowpages.SpecflowTests.AcceptanceTest
{
    [Binding]
    public class EditLanguageSteps
    {
        [Given(@"I clicked on language tab under Profile page")]
        public void GivenIClickedOnLanguageTabUnderProfilePage()
        {
            Thread.Sleep(1500);

            //Click on Profile Page
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();
        }
        
        [Given(@"I Clicked on edit button of already entered language")]
        public void GivenIClickedOnEditButtonOfAlreadyEnteredLanguage()
        {
            //Click on the Edit Button for the first row
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]")).Click();
        }
        
        [When(@"I change the level of language")]
        public void WhenIChangeTheLevelOfLanguage()
        {
            //click on the dropdown list
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).Click();

            //change the level by selecting dropdown list
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[3];
            Lang.Click();
        }
        
        [When(@"clicked on update button")]
        public void WhenClickedOnUpdateButton()
        {
            //click on update button
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }
        
        [Then(@"the table is updated with change")]
        public void ThenTheTableIsUpdatedWithChange()
        {
            try
            {
                Thread.Sleep(2000);
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");
                String ExpectedValue = "Fluent";
                String ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]")).Text;
                if (ActualValue == ExpectedValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language is level is updated successfully.");

                }


            }

            catch
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
        }
    }
}
