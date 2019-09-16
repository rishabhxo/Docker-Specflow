using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using RelevantCodes.ExtentReports;
namespace SpecflowTests.AcceptanceTest
{
	[Binding]
	public class AddNewLanguagesSteps
	{
		
		[Given(@"I am on the Languages tab")]
		public void GivenIAmOnTheLanguagesTab()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Languages tab
			Driver.driver.FindElement(By.XPath("//a[contains(@class,'item')][contains(text(),'Languages')]")).Click();
		}

		[Scope(Tag = "AddLanguages")]
		[Given(@"I have clicked the Add New button")]
		public void GivenIHaveClickedTheAddNewButton()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Add New button
			Driver.driver.FindElement(By.XPath("//div[contains(@class,'active')]//div[contains(@class,'button')][contains(text(),'Add New')]")).Click();
		}

		[Given(@"I have input Language name ""(.*)"" and chosen Language level ""(.*)""")]
		public void GivenIHaveInputLanguageNameAndChosenLanguageLevel(string name, string level)
		{
			// Input Language name 
			Driver.driver.FindElement(By.Name("name")).SendKeys(name);

			// Choose Language level "Native/Bilingual"
			Driver.driver.FindElement(By.Name("level")).SendKeys(level);
		}

		[Scope(Tag ="AddLanguages")]
		[When(@"I click the Add button")]
		public void WhenIClickTheAddButton()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Add button
			Driver.driver.FindElement(By.XPath("//input[@type='button'][@value='Add']")).Click();
		}

       

        [Then(@"The new Language '(.*)' record added to my listing")]
        public void ThenTheNewLanguageRecordAddedToMyListing(string name)
        {
            // Verify if add the new Language successfully 

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                //Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");
                String expectedValue = name;
                string actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                //Check if expected value is equal to actual value
                if (expectedValue == actualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");

                    Assert.That(actualValue, Is.EqualTo(expectedValue));

                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }


            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}