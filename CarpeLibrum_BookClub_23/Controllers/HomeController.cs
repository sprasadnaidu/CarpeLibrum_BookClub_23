using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarpeLibrum_BookClub_23.Models;
using Rotativa;
using System.IO;

namespace CarpeLibrum_BookClub_23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SplashScreen()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact() //sends the empty Contact form to the browser
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Message message) //gets the form back with all the info from the user, also creates an association between classes
        {
            if (ModelState.IsValid) //if the message is a valid object - meaning it's not null then
            {
                //add a time stamp to the message when the user posted the form
                message.DateOfMessage = DateTime.Now.Date;
                //and then send the message details to a confirmation page
                return View("Confirmation", message);
            }
            //if the message model is null then send the empty form back to the user
            return View(message);
        }

        public ActionResult Fees()
        {
            return View();
        }

        public ActionResult ConvertPDF()
        {
            //this is the name of the pdf file once the Fees web page gets converted
            string fileName = "MembershipFees.pdf";
            //gets all the cookies that were sent by the client stored in a dictionary as a key value pair
            var cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);

            //the object actionaspdf that will call the Fees method and set the layout of the pdf file
            var actionPDF = new ActionAsPdf("Fees")
            {
                FileName = fileName,
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                PageMargins = new Rotativa.Options.Margins(5, 10, 5, 10),
                FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName,
                Cookies = cookies
            };

            //file builder
            byte[] applicationPDFData = actionPDF.BuildFile(ControllerContext);

            return actionPDF;
        }

        public ActionResult MapLocation()
        {
            return View();
        }

        public ActionResult AudioBooks()
        {
            //create an instance of list that will store sound objects
            //I will store all the audio files in this list
            List<Sound> sounds = new List<Sound>(); //used to add or manipulate data

            //add instances of Sound to the list
            sounds.Add(new Sound() { Name = "Book1", FilePath = "~/Sounds/sound_1.mp3" });
            sounds.Add(new Sound() { Name = "Book2", FilePath = "~/Sounds/sound_2.mp3" });
            sounds.Add(new Sound() { Name = "Book3", FilePath = "~/Sounds/sound_3.mp3" });
            sounds.Add(new Sound() { Name = "Book4", FilePath = "~/Sounds/sound_4.mp3" });
            sounds.Add(new Sound() { Name = "Book5", FilePath = "~/Sounds/sound_5.mp3" });
            sounds.Add(new Sound() { Name = "Book6", FilePath = "~/Sounds/sound_6.mp3" });
            sounds.Add(new Sound() { Name = "Book7", FilePath = "~/Sounds/sound_7.mp3" });

            //sending the list of sounds to the AudioBooks.cshtml share the list items will be displayed
            return View(sounds);
        }

        public ActionResult Meetings()
        {
            return View();
        }

        public ActionResult Room_1()
        {
            return View();
        }

        public ActionResult Room_2()
        {
            return View();
        }

        public ActionResult Room_3()
        {
            return View();
        }

        public ActionResult Room_4()
        {
            return View();
        }
    }
}