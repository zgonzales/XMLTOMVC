using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XMLCAREERS.Models;
using System.Xml;
using System.Collections.Generic;

namespace XMLCAREERS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Div> divs = new List<Div>();
            List<Link> links = new List<Link>();
            XmlDocument doc = new XmlDocument();

            doc.Load("XMLFile1.xml");

            foreach (XmlNode node in doc.SelectNodes("/Content/Div"))
            {
                links.Add(new Link {
                    Href = node["Link"]["Href"].InnerText,
                    Label = node["Link"]["Label"].InnerText
                });

                divs.Add(new Div
                {
                    Text = node["Text"].InnerText,
                    Links = links
                });
            }

            return View(divs);
        }

        public IActionResult About()
        {

            

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
