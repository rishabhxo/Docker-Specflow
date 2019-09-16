using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class DeleteManageListingsSteps
    {
		public DeleteManageListingsSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Delete all services of the last page");
		}

		public int LastPageNumber { get; set; }

		[Given(@"I have clicked the Manage Listings tab")]
        public void GivenIHaveClickedTheManageListingsTab()
        {
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Manage Listings tab
			Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();
		}

		[Given(@"I have selected the last service of the last page")]
        public void GivenIHaveSelectedTheLastServiceOfTheLastPage()
        {
			// Save the last page number
			LastPageNumber = Convert.ToInt32(Driver.driver.FindElement(By.XPath("//div[contains(@class,'pagination')]/button[last() - 1]")).Text);

			// Go to the last page 
			Driver.driver.FindElement(By.XPath("//div[contains(@class,'pagination')]/button[last() - 1]")).Click();
			Thread.Sleep(500);
		}
        
		[When(@"I click the Yes button of the popup delete dialog")]
		public void WhenIClickTheYesButtonOfThePopupDeleteDialog()
		{
			// Check how many listings on the last page
			int listingCount = Driver.driver.FindElements(By.XPath("//tbody/tr")).Count;

			for (int i = 0; i < listingCount; i++)
			{
				// Click on the delete icon of the last service
				Driver.driver.FindElement(By.XPath("//tr[last()]//i[@class='remove icon']")).Click();
				Thread.Sleep(500);

				// Click on the "Yes" button of the popup dialog
				Driver.driver.FindElement(By.XPath("//div[contains(@class,'tiny modal')]//button[contains(text(),'Yes')]")).Click();
				Thread.Sleep(1000);
			}
		}

        [Then(@"The last service should be deleted")]
        public void ThenTheLastServiceShouldBeDeleted()
        {
            // Verify if delete service skill successfully and ListingManagement has no service
            Assert.IsNull(Driver.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]")));

            Thread.Sleep(1000);
			}
    }
}
