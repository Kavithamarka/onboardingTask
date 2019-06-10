using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature3Steps
    {
        [Given(@"I have entered url, logged in and clicked on Profile tab")]
        public void GivenIHaveEnteredUrlLoggedInAndClickedOnProfileTab()
        {
            Thread.Sleep(1500);

            //Click on Profile Page
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();
        }
        
        [Given(@"I have clicked on addNew button and enter language (.*)")]
        public void GivenIHaveClickedOnAddNewButtonAndEnterTelugu(String language)
        {
                                                 

           //Click on addlanguage button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //language entered from scenario outline
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(language);

            //language level chosen from dropdown list
            IWebElement Level = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[2];
            Level.Click();
        }
        
        [When(@"I clicked on add button")]
        public void WhenIClickedOnAddButton()
        {
            //pressing on add Button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
        }
        
        [Then(@"the languages showed in the table")]
        public void ThenTheLanguagesShowedInTheTable()
        {
            try
            {
                string[] a = new string[3];
                a[0] = "English";
                a[1] = "Hindi";
                a[2] = "Telugu";
                a[3] = "Tamil";

                //start reports
                CommonMethods.ExtentReports();
                Thread.Sleep(3000);
                CommonMethods.test = CommonMethods.extent.StartTest("Language entry through scenario outline");
                Thread.Sleep(3000);
                String beforeXpath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[";
                String afterXpath = "]/tr/td[1]";
                
                for (int i = 0; i <= 4; i++)
                {
                    String languageName = Driver.driver.FindElement(By.XPath(beforeXpath +"i"+afterXpath)).Text;

                    if (languageName == a[0] || languageName == a[1] || languageName == a[2] || languageName == a[3])

                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Language is entered successfully");
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Languages not entered successfully");
                    }
                }


            }

            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }


        }
    }
}
