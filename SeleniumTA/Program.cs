using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.IO;



namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader tIn = Console.In;
            TextWriter tOut = Console.Out;

            bool assertion1 = false;
            bool assertion2 = false;
            bool assertion3 = false;
            bool assertion4 = false;
            bool assertion5 = false;


            //Test Registration and Application Process starting from Index page
            //click the register nav to get started.


            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(("http://localhost:57101/"));

            IWebElement element = driver.FindElement(By.Id("searchBox"));
            element.Click();
            element.SendKeys("ben");

            IWebElement elementSearchBtn = driver.FindElement(By.Id("searchBtn"));
            elementSearchBtn.Click();


            tOut.Write("We will first test our seeding. Our list should include Ben Felix ");

            tOut.Write("\n press enter to continue. ");
            tOut.Write("\n");
            String password = tIn.ReadLine(); //  pause the console get tester to input password.

            // Send Keys to each field and hit submit. Green Check marks should appear.

            string tableData;

            IWebElement tableElement = driver.FindElement(By.Id("Ben Felix"));

            tableData = tableElement.Text;
            String proceed;
            if (tableData == "Ben Felix")
            {
                assertion1 = true;
                tOut.Write("Assertion 1 passed Ben Felix Present ");

                tOut.Write("press enter to continue. ");
                tOut.Write("\n");
                proceed = tIn.ReadLine();

            }
            tOut.Write("Now we will test the Add human function \n");
 
            tOut.Write("press enter to continue. ");
            tOut.Write("\n");
            proceed = tIn.ReadLine();





            element = driver.FindElement(By.Id("addBtn"));
            element.Click();

            tOut.Write("The Add Human form should now be visible \n");

            tOut.Write("please enter a test name and press enter: ");
            tOut.Write("\n");
            string testName = tIn.ReadLine();

            element = driver.FindElement(By.Id("fullName"));
            element.SendKeys(testName);

            tOut.Write("The save button should now be enabled. \n");

            tOut.Write("please enter an address and press enter: ");
            tOut.Write("\n");
            string testAddress = tIn.ReadLine();

            element = driver.FindElement(By.Id("address"));
            element.SendKeys(testAddress);

            element = driver.FindElement(By.Id("age"));
            element.SendKeys("33");

            element = driver.FindElement(By.Id("hair"));
            element.SendKeys("Blonde");

            element = driver.FindElement(By.Id("interests"));
            element.SendKeys("Water Polo, Golf, Travel");

            element = driver.FindElement(By.Id("image"));
            element.SendKeys("http://66.media.tumblr.com/tumblr_m6vfbyyfn91r8grwbo1_500.jpg");



            element = driver.FindElement(By.Id("saveBtn"));
            element.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            tOut.Write("Now we will test the filter function by entering \n any part of the name you submitted. ");
            tOut.Write("please enter any or all of the name you submitted: ");
            string partialName = tIn.ReadLine();


            element = driver.FindElement(By.Id("searchBox"));
            element.Click();
            element.SendKeys(partialName);

            elementSearchBtn = driver.FindElement(By.Id("searchBtn"));
            elementSearchBtn.Click();

            tableElement = driver.FindElement(By.Id(testName));

            if (tableData == testName)
            {
                assertion2 = true;
                tOut.Write("Assertion 2 passed, "+testName+" was found in our search");
                tOut.Write("press enter to continue. ");
                tOut.Write("\n");
                proceed = tIn.ReadLine();
                tOut.Write("\n \n \n");
                

            }

            tOut.Write("press enter to continue. ");
            proceed = tIn.ReadLine();

            tOut.Write("Finally lets assert the rest of the fileds were succesfully \n inserted and returned. ");
            tOut.Write("\n press enter to continue. ");
            proceed = tIn.ReadLine();

            

            tableElement = driver.FindElement(By.Id(testName+"age"));
            string testAge = tableElement.Text;

            tableElement = driver.FindElement(By.Id(testName + "hair"));
            string testHair = tableElement.Text;

            tableElement = driver.FindElement(By.Id(testName + "interests"));
            string testInterests = tableElement.Text;

 

            if (testAge == "33")
            {
                assertion3 = true;
                tOut.Write("Assertion 3 passed Age was entered and returned ");

                tOut.Write("press enter to continue. ");
                tOut.Write("\n");
                proceed = tIn.ReadLine();

            }

            if (testHair == "Blonde")
            {
                assertion4 = true;
                tOut.Write("Assertion 4 passed Hair was entered and returned ");

                tOut.Write("press enter to continue. ");
                tOut.Write("\n");
                proceed = tIn.ReadLine();

            }

            if (testInterests == "Water Polo, Golf, Travel")
            {
                assertion5 = true;
                tOut.Write("Assertion 5 passed Interests were entered and returned ");

                tOut.Write("press enter to continue. ");
                tOut.Write("\n");
                proceed = tIn.ReadLine();

            }



            if (assertion1 && assertion2 && assertion3 && assertion4 && assertion5)
            {
                tOut.Write("All Assertions returned PASSED");
  
                tOut.Write("\n");

                tOut.Write("press enter to end. ");
                proceed = tIn.ReadLine();
            }
            else
            {
                tOut.Write("Not All Assertions returned true.");
                tOut.Write("press enter to continue. ");
                tOut.Write("\n");

                tOut.Write("press enter to end. ");
                proceed = tIn.ReadLine();
            }

       
         
        }
    }
}
