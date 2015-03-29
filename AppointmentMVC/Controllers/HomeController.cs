using AppointmentMVC.Model;
using AppointmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppointmentMVC.Controllers
{
    public class HomeController : Controller
    {
        DB db = DB.Instance;
        public ActionResult Index()
        {
            return View(db.Appointments);//ok
        }
        public ActionResult Details(int id)
        {
            Appointment appt = db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            return View(appt);
        }
        public ActionResult AddAppt()
        {
            return View(new Appointment());
        }
        [HttpPost]
        public ActionResult AddAppt(Appointment appt)
        {
            appt.AppointmentId = db.Appointments.OrderBy(x => x.AppointmentId).LastOrDefault().AppointmentId + 1;
            db.Appointments.Add(appt);
            return RedirectToAction("Index");
        }
        public ActionResult EditAppt(int id)
        {
            Appointment editAppt = db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            return View(editAppt);
        }
        [HttpPost]
        public ActionResult EditAppt(Appointment appt)
        {
            foreach (var a in db.Appointments)
            {
                if (a.AppointmentId == appt.AppointmentId)
                {
                    a.Description = appt.Description;
                    a.WhoWith = appt.WhoWith;
                    a.TimeStart = appt.TimeStart;
                    a.TimeEnd = appt.TimeEnd;
                }
            }
            return (RedirectToAction("Index"));
        }
        public ActionResult DeleteAppt(int id)
        {
            Appointment deleteAppt = db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            db.Appointments.Remove(deleteAppt);
            return RedirectToAction("Index");
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
    }
}