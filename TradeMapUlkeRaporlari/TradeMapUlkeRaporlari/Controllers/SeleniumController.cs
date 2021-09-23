using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkLibrary;
using BusinessLibrary;
using System.Text;

namespace TradeMapUlkeRaporlari.Controllers
{
    public class SeleniumController : Controller
    {
        // GET: Selenium
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcEkleIslem(FormCollection collection)
        {
            string ProcUlkeAd = collection["txtProcUlkeAd"].ToString();
            string Mail = collection["txtMail"].ToString();
            string Sifre = collection["txtSifre"].ToString();


            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trademap.org/Index.aspx");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#ctl00_MenuControl_Label_Login")).Click();
            Thread.Sleep(1500);
            IWebElement username = driver.FindElement(By.Name("Username"));
            IWebElement password = driver.FindElement(By.Name("Password"));
            IWebElement loginbtn = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div/div/form/fieldset/div[4]/div/button"));
            username.SendKeys(Mail);
            password.SendKeys(Sifre);
            loginbtn.Click();
            Thread.Sleep(2000);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Login Olundu");

            driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Product_Input")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Product_c0")).Click();
            Thread.Sleep(4000);
            IWebElement country = driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Country_Input"));
            Thread.Sleep(2000);
            country.SendKeys(" " + ProcUlkeAd);
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Country_c0")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#ctl00_PageContent_Button_TimeSeries")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#ctl00_NavigationControl_DropDownList_OutputOption > option:nth-child(2)")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#ctl00_PageContent_GridViewPanelControl_DropDownList_PageSize > option:nth-child(5)")).Click();
            Thread.Sleep(1000);


            IList<IWebElement> SatirSayisi = driver.FindElements(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr"));
            int elemanSayisi = SatirSayisi.Count;



            for (int i = 4; i <= elemanSayisi; i++)

            {
                IWebElement ıd = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(2)"));
                IWebElement ıhracat1 = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-of-type(" + i + ") > td:nth-child(4)"));
                Console.WriteLine(ıd + " " + ıhracat1);

            }
            return View();
        }


        [HttpPost]
        public ActionResult EkleIslem(FormCollection collection)
        {


            string UlkeAd = collection["txtUlkeAd"].ToString();



            //Siteye Giriş//
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trademap.org/Index.aspx");
            Thread.Sleep(3000);

            //Product code - region name seçim alanı//
            driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Product_Input")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Product_c0")).Click();
            Thread.Sleep(4000);

            IWebElement country = driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Country_Input"));
            Thread.Sleep(2000);
            country.SendKeys(" " + UlkeAd);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#ctl00_PageContent_RadComboBox_Country_c0")).Click();
            Thread.Sleep(3000);

            //Yearly btn basılması//
            driver.FindElement(By.CssSelector("#ctl00_PageContent_Button_TimeSeries")).Click();
            Thread.Sleep(3000);

            //page sayısını 10 olarak belirleme// 
            driver.FindElement(By.CssSelector("#ctl00_PageContent_GridViewPanelControl_DropDownList_NumTimePeriod > option:nth-child(5)")).Click();
            Thread.Sleep(2000);




            //Satır Sayısı//
            IList<IWebElement> SatirSayisi = driver.FindElements(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr"));
            int elemanSayisi = SatirSayisi.Count;

            List<string> ozelUlekAd = new List<string>();
            List<string> ozelUlkeYil = new List<string>();
            List<int> ozelithalat = new List<int>();
            List<int> ozelihracat = new List<int>();
            List<int> ozelhacim = new List<int>();
            List<int> ozeldenge = new List<int>();

            List<string> genelUlkeAd = new List<string>();
            List<string> genelUlkeYil = new List<string>();
            List<string> ithalatUlkeAd = new List<string>();
            List<long> genelithalat = new List<long>();
            List<string> ihracatUlkeAd = new List<string>();
            List<long> genelihracat = new List<long>();




            PageItem item = new PageItem();
            using (TradeMapTicaretDB db = new TradeMapTicaretDB())
            {

                //SQL DE GÖNDERİLECEK YER TRADEMAPTİCARET -> Genel_Ulke_Raporu//
                //Import kısmı//
                for (int i = 3; i <= 12; i++)
                {
                    IWebElement Year = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-of-type(2) > th:nth-of-type(" + i + ")"));
                    string Yil = Year.Text;
                    Yil = Yil.Substring(18);

                    for (int j = 4; j < elemanSayisi; j++)
                    {

                        IWebElement ImportUlkeAd = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-child(" + j + ") > td:nth-child(2)"));
                        IWebElement Import = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-child(" + j + ") > td:nth-child(" + i + ")"));
                        String ImportUlkeAdi = ImportUlkeAd.Text;
                        String import = (Import.Text).Replace(",", "");
                        long intimport = (long)Convert.ToInt64(import);

                        ithalatUlkeAd.Add(ImportUlkeAdi);
                        genelithalat.Add(intimport);
                        genelUlkeAd.Add(UlkeAd);
                        

                    }


                }

                driver.FindElement(By.CssSelector("#ctl00_NavigationControl_DropDownList_TradeType > option:nth-child(1)")).Click();
                Thread.Sleep(2000);


                //Export kısmı//
                for (int i = 3; i <= 12; i++)
                {
                    IWebElement Year = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-of-type(2) > th:nth-of-type(" + i + ")"));
                    string Yil = Year.Text;
                    Yil = Yil.Substring(18);


                    for (int j = 4; j < elemanSayisi; j++)
                    {

                        IWebElement ExportUlkeAd = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-child(" + j + ") > td:nth-child(2)"));

                        IWebElement Export = driver.FindElement(By.CssSelector("#ctl00_PageContent_MyGridView1 > tbody > tr:nth-child(" + j + ") > td:nth-child(" + i + ")"));

                        String ExportUlkeAdi = ExportUlkeAd.Text;
                        String export = (Export.Text).Replace(",", "");
                        long intexport = (long)Convert.ToInt64(export);

                        ihracatUlkeAd.Add(ExportUlkeAdi);
                        genelihracat.Add(intexport);
                        genelUlkeYil.Add(Yil);




                    }


                }
                for (int i = 0; i < 10*elemanSayisi; i++)
                {
                    item.lstGenelUlke = db.Proc_GenelUlkeRapor_Islem("Yeni", genelUlkeAd[i], genelUlkeYil[i], ithalatUlkeAd[i], genelithalat[i], ihracatUlkeAd[i], genelihracat[i]).ToList();
                }

                
            }

            //ViewBag.Message = String.Format("işleminiz tamamlandı");


            return View();
        }
    }

    public class PageItem
    {
        public List<Proc_GenelUlkeRapor_Islem_Result> lstGenelUlke = new List<Proc_GenelUlkeRapor_Islem_Result>();
        public List<Proc_OzelUlkeRapor_Islem_Result> lstOzelUlke = new List<Proc_OzelUlkeRapor_Islem_Result>();
    }
}

