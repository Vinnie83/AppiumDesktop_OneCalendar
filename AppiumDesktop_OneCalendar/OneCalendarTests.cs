using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktop_OneCalendar
{
    public class OneCalendarTests
    {
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private const string appiumServer = @"http://127.0.0.1:4723/wd/hub";
        private const string appLocation = "64885BlueEdge.OneCalendar_8kea50m9krsh2!App";





        [SetUp]
        public void OpenApp()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);



        }

        [TearDown] 
        
        public void CloseApp() 
        
        {  
            
            driver.Quit();
        
        } 
        

        [Test]
        public void Test_CheckAddedAppointment()
        {
            Thread.Sleep(3000);

            
            var buttonPlus = driver.FindElementByClassName("Button");
            buttonPlus.Click();

            
            var contextMenu = driver.FindElementByClassName("UIContextMenuButton");
            contextMenu = driver.FindElementByName("Add appointment");
            contextMenu.Click();

            Thread.Sleep(3000);

            var inputField = driver.FindElementByAccessibilityId("txtTitle");
            inputField.Click(); 
            inputField.SendKeys("Pregled Ali");

            var datePicker = driver.FindElementByAccessibilityId("datepicker");
            datePicker.Click();

            var dateTwentynine = driver.FindElementByClassName("CalendarViewDayItem");
            dateTwentynine.Click();

            var saveButton = driver.FindElementByAccessibilityId("labelTxt");
            saveButton.Click();

            Thread.Sleep(3000);

            var okSavebutton = driver.FindElementByAccessibilityId("Popup Window");
            okSavebutton = driver.FindElementByName("Yes");
            okSavebutton.Click();

            var savedItem = driver.FindElementByName("Pregled Ali");

            Assert.That(savedItem, Is.Not.Null);
            Assert.That(savedItem.Text, Is.EqualTo("Pregled Ali")); 

        }
    }
}