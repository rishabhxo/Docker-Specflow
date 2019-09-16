﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecflowPages
{
	public class Driver
	{
		//Initialize the browser
		public static IWebDriver driver { get; set; }

		public static void Initialize()
		{
            try
            {
                //Defining the browser
                driver = new ChromeDriver();
                TurnOnWait();

                //Maximise the window
                driver.Manage().Window.Maximize();

            }
            catch (TimeoutException e)
            {
                Thread.Sleep(5000);
                Console.WriteLine(e);
            }

        }

        public static string BaseUrl
		{
			get { return ConstantUtils.URL; }
		}


		//Implicit Wait
		public static void TurnOnWait()
		{
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

		}

		public static void NavigateUrl()
		{
			driver.Navigate().GoToUrl(BaseUrl);
		}

		//Close the browser
		public static void Close()
		{
			driver.Close();
		}
	}
}
