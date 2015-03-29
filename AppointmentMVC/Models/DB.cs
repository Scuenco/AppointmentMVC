using AppointmentMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Using the Singleton pattern
namespace AppointmentMVC.Models
{
    public class DB
    {
        //define an empty private constructor
        private DB() { }
        //properties ( as many as you want )
        public List<Appointment> Appointments { get; set; }
        //define the Singleton 
        private static DB _instance;
        //public static property
        public static DB Instance
        {
            get
            {
                return _instance ?? (_instance = CreateDB());
            }
        }
        //same as writing if (_instance == null) {_instance = new DB() {...}}
        private static DB CreateDB()
        {
            return new DB()
            {
                Appointments = new List<Appointment>()
                {
                    new Appointment() {AppointmentId = 1, WhoWith = "Dr. S. Miller", Description = "checkup",TimeStart= DateTime.Now, TimeEnd= DateTime.Now.AddDays(2)},
                    new Appointment() {AppointmentId = 2, WhoWith = "Dr. J. Tran", Description = "checkup",TimeStart=DateTime.Now, TimeEnd= DateTime.Now.AddDays(1)},
                    new Appointment() {AppointmentId = 3, WhoWith = "Dr. Hewlitt", Description = "checkup",TimeStart=DateTime.Now, TimeEnd= DateTime.Now.AddDays(2)},
                    new Appointment() {AppointmentId = 4, WhoWith = "Dr. M. Miller", Description = "checkup",TimeStart=DateTime.Now, TimeEnd= DateTime.Now.AddDays(3)},
                }
            };
        }
    }
}