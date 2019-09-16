using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
	[Binding]
	public class Start : Driver
    {
		[BeforeScenario(Order = 1)]
        public void SetUp()
		{ 
			CommonMethods.ExtentReports();

            //Launch the browser
            Initialize();
			Driver.NavigateUrl();
		}

		[BeforeScenario("SignedIn", Order = 2)]
		public void SignIn()
		{
			//Call the Login Class            
			SpecflowPages.Utils.LoginPage.LoginStep();
		}

        [AfterScenario]
        public void TearDown()
        {
			// Screenshot
			string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.extent.EndTest(CommonMethods.test);

			// calling Flush writes everything to the log file (Reports)
			CommonMethods.extent.Flush();

			//Close the browser
			Driver.driver.Quit();
        }
    }
}
