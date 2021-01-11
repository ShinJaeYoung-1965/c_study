using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleSearch_with_selenium
{

    public partial class Form1 : Form
    {
        //private ChromeDriverService _driverService = null;
        //private ChromeOptions _options = null;
        //private ChromeDriver _driver = null;
        //IWebDriver driver = new ChromeDriver();
        private ChromeDriverService service = ChromeDriverService.CreateDefaultService("D:/1개인/비업무용_Study/C#/Reference");
        private ChromeOptions option = new ChromeOptions();
        
            //List<GoldenCross> goldens = new List<GoldenCross>();

        



        public Form1()
        {
            InitializeComponent();
            service.HideCommandPromptWindow = true;
            //option.AddArguments("headless");
            option.AddArgument("disable-gpu");
            //_driverService = ChromeDriverService.CreateDefaultService("D:/1개인/비업무용_Study/C#/Reference");
            //_driverService.HideCommandPromptWindow = true;

            //_options = new ChromeOptions();
            //_options.AddArgument("disable-gpu");
            ////_options.AddArgument("headless");
            //_driver = new ChromeDriver(_driverService, _options);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //_driver.Navigate().GoToUrl(" http://172.31.7.80:8081/WS_ACK.asmx?WSDL");
            //_driver.Navigate().GoToUrl("https://google.co.kr");
            //_driver.Manage().Window.Maximize();
            using (IWebDriver driver = new ChromeDriver(service, option))
            {
                driver.Navigate().GoToUrl(" http://172.31.7.80:8081/WS_ACK.asmx?WSDL");
                Thread.Sleep(3000);
                List<IWebElement> list = driver.FindElements(By.CssSelector("body div div div div table tbody tr")).ToList();
                Thread.Sleep(3000);
                foreach (IWebElement x in list)
                {
                    MessageBox.Show("뭔가 가져왔다");
                    try
                    {
                        List<IWebElement> list1 = x.FindElements(By.CssSelector("td")).ToList();
                        MessageBox.Show("뭔가 가져왔다111111111111111111111111111111111     "+ list1.ToString());
                        txtDisplay.Text = list1.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("에러발생 ==>  " + ex.Message);
                        throw;
                    }
                }
            }




            Thread.Sleep(3000);

            //_driver.FindElement(By.Name("q")).SendKeys(txt_search.Text.ToString() + " 가사");
            
            //Thread.Sleep(3000);
            //_driver.FindElement(By.Name("btnK")).Click();
            //txtDisplay.Text = "";
            //Thread.Sleep(5000);
            //_driver.FindElement(By.XPath("//*[@id=\"tsuid12\"]/g-more-link/div")).Click();
            //Thread.Sleep(1000);
            //var text1 = _driver.FindElement(By.XPath("//*[@id=\"tsuid12\"]/span/div/div/div[2]/div/div/div/div/div/div[1]"));
            
            /////html/body/div[7]/div[2]/div[10]/div[1]/div[2]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[1]/g-more-link/div/span[2]/span[1]
            
            //String text2 = text1.Text;
            //txtDisplay.Text = text2;

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
