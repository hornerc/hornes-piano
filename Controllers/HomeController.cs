using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using SimpleHornesPiano.Models;

namespace SimpleHornesPiano.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            //Create the body of the email
            string body = string.Format("Name: {0}<br/ >Email: {1}<br />Subject: {2}<br />Message: {3}", contact.Name, contact.Email, contact.Subject, contact.Message);
            Debug.WriteLine(body);
            //Create and configure a MailMessage object
            MailMessage msg = new MailMessage(
                "no-reply@hornespianoservice.com", //From address (email on your hosting account
                "hornespianoservice@gmail.com",  // To (who will receive this email
                contact.Subject, // subject submitted by user
                body
                );
            // configure msg
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;

            //Create and configure an SmtpClient object
            SmtpClient client = new SmtpClient("205.144.171.87");
            client.Credentials = new NetworkCredential("no-reply@hornespianoservice.com", "GreenGiant22!");

            //Send the email
            using (client)
            {
                /*
                try/catch
                used to test 'dangerous' code and keep the application from blowing up

                try - test code that may or may not execute correctly

                catch - will execute only if the code in the try threw an error
                - multiple catch blocks may be used to target specific error
                - we are using the generic catch which will run regardless of the error type
                */
                try
                {
                    if (ModelState.IsValid)
                    {
                        client.Send(msg);
                        return View("ContactConfirmation", contact);
                        //step 7: Create ContactConfirmation View
                        // right clicked Views folder and added a View
                    }
                }
                catch
                {
                    ViewBag.ErrorMessage = "There was an error in sending your email." +
                                            "Please try again";

                }
            }
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
    }
}