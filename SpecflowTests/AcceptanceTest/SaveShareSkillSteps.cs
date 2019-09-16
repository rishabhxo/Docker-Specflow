using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class SaveShareSkillSteps
    {

        [Given(@"I have clicked the Share Skill button")]
        public void GivenIHaveClickedTheShareSkillButton()
        {
            // Wait 0.5 second
            Thread.Sleep(500);

            // Click the Share Skill button
            Driver.driver.FindElement(By.XPath("//section[@class='nav-secondary']//a[contains(@class,'button')][contains(text(),'Share Skill')]")).Click();
        }

        [Given(@"I have input Title ""(.*)"", Description ""(.*)"" and Category ""(.*)""")]
        public void GivenIHaveInputTitleDescriptionAndCategory(string title, string description, string category)
        {
            // Wait 0.5 second
            Thread.Sleep(500);

            // Input Title "Manual Testing"
            Driver.driver.FindElement(By.Name("title")).SendKeys(title);

            // Input Description "Functional"
            Driver.driver.FindElement(By.Name("description")).SendKeys(description);
            Thread.Sleep(500);

            // Select Category "Fun & Lifestyle"
            Driver.driver.FindElement(By.Name("categoryId")).SendKeys(category);
        }

        [Given(@"I have also input Subcategory ""(.*)"", Tags ""(.*)"" and Skill-Exchange tags ""(.*)""")]
        public void GivenIHaveAlsoInputSubcategoryTagsAndSkill_ExchangeTags(string subcategory, string tags, string exchangetags)
        {
            // Select Subcategory "Gaming"
            Driver.driver.FindElement(By.Name("subcategoryId")).SendKeys(subcategory);

            // Input Tags "Manual"
            Driver.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[1]")).SendKeys(tags);
            Driver.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[1]")).SendKeys(Keys.Enter);

            // Input Skill-Exchange tags "Automation"
            Driver.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[2]")).SendKeys(exchangetags);
            Driver.driver.FindElement(By.XPath("(//input[@type='text'][@placeholder='Add new tag'])[2]")).SendKeys(Keys.Enter);
        }

        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {
            // Click the Save button
            Driver.driver.FindElement(By.XPath("//input[@type='button'][@value='Save']")).Click();
            Thread.Sleep(1000);
        }


        [Then(@"The service with Title '(.*)' should be saved and navigate to the Manage Listings page")]
        public void ThenTheServiceWithTitleShouldBeSavedAndNavigateToTheManageListingsPage(string title)
        {

            // Verify if add the skill successfully and navigate to ListingManagement
            Assert.IsNotNull(Driver.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            try
            {
                //Go to Manage Listing Tab
                Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();
                IWebElement GridNextPageLink = Driver.driver.FindElement(By.XPath("//button[contains(.,'>')]"));
                bool loop = true;
                IList<IWebElement> tblSkillList = Driver.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr"));
                if (tblSkillList.Count > 0)
                {
                    CommonMethods.test = CommonMethods.extent.StartTest("Save a new service");
                    //Get the row count in table
                    var skillRowCount = tblSkillList.Count;
                    while (loop)
                    {
                        for (int i = 1; i <= skillRowCount; i++)
                        {
                            //Get the row value from ServiceList table
                            IWebElement ShareTitle = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + i + "]/td[3]"));

                            if (ShareTitle.Text == title)
                            {
                                CommonMethods.test.Log(LogStatus.Pass, "Test Pass,Share Skill Successfull");
                                SaveScreenShotClass.SaveScreenshot(Driver.driver, "ServiceAdded");

                                ///Assertion
                                Assert.AreEqual(title, ShareTitle.Text);
                                loop = false;
                                return;

                            }
                        }
                        //Click next page
                        GridNextPageLink.Click();
                    }
                }
            }
            catch (Exception e)
            {
                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Share Skill Unsuccessful" + e.Message);
            }
        }

    }
}

