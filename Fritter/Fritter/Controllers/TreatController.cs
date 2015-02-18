using Fritter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fritter.Controllers
{

    public class TreatController : Controller
    {

         List<Treat> allTreats = new List<Treat>();

         public TreatController()
         {
             allTreats.Add(new Treat("I <3 cis268!!!", "SaraBoyd"));
             allTreats.Add(new Treat("Lectureship week is my fave", "SpencerToTheC"));
             allTreats.Add(new Treat("Roy Sharp has too much energy for a 7:30 class.", "Babambambi"));

         }

        /*
         * 
         * {username}/{treatId}
            fritter.com => TreatController.AllTreats(enum treatOrderMode) 
            fritter.com/tyler => TreatController.SingleUserTreats(string userName)
            fritter.com/tyler/34 => TreatController.SingleUserTreats(string userName, int treatId) 
         */
        // GET: Treat
        //[Route("")]
        public ActionResult Index()
        {
            return View(allTreats);
        }

        [HttpPost]
        
        public ActionResult Index(Treat treat)
        {

            if (!Request.IsAuthenticated)
            {
                return View(allTreats);
            }

            // lookup username/user in ASP.NET identity 
            treat.UserName = User.Identity.Name;
            allTreats.Insert(0, treat);

            return View(allTreats);
        }

        [Route("{userName}")]
        public ActionResult SingleUserTreats(string userName)
        {
            //do complex stuff 
            return View();
        }

        [Route("{userName}/{treatId:int}")]
        public ActionResult SingleUserTreats(string userName, int treatId)
        {
            return View();
        }


    }
}