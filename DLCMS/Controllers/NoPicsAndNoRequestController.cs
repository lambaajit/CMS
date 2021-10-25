using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using DLCMS.Models;

namespace DLCMS.Controllers
{
    public class NoPicsAndNoRequestController : Controller
    {
        IT_DatabaseEntities itdb = new IT_DatabaseEntities();
        HRDDLEntities hrdb = new HRDDLEntities();
        // GET: NoPicsAndNoRequest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckPhotos()
        {

            return View(retrivestaffwithoutpics());
        }

        public List<PhotoMissingVM> retrivestaffwithoutpics()
        {
            List<PhotoMissingVM> pm = new List<PhotoMissingVM>();
            int i = 1; 
            DateTime dt = DateTime.Now.Date;

            //Filtering Staff already Booked for PhotoSession
            List<int> sessionids = itdb.PhotoSessions.Where(x => x.Date > DateTime.Now).Select(y => y.Id).ToList();
            var booked = itdb.PhotoSession_StaffAttendance.Where(x => sessionids.Contains(x.EventId)).Select(x => x.EmpName).ToList();

            //Filtering London Offices
            List<string> offices = new List<string>() { "Harrow", "Dalston", "City Of London", "Croydon", "Shepherds Bush" };
            List<string> officecodes = hrdb.Offices.Where(x => offices.Contains(x.office_name)).Select(y => y.office_code).ToList();

            //filtering out manual names
            string[] name = new string[] { "Arvin Bharj", "Lubna Chauhan","Sonal Ruparelia","Vincent Davis", "Ellie Sabet","Ariola Toslloukou" };

            var res = hrdb.Emp_Details.Where(x => x.employed.Equals("1") && x.Picture_website == true && x.start_date < dt && !booked.Contains(x.forename + " " + x.surname) && !name.Contains(x.forename + " " + x.surname) && !(x.forename + " " + x.surname).Contains("Donald") && officecodes.Contains(x.office_code) && x.start_date.Value.Year > 2018).Select(y => y).OrderByDescending(x => x.start_date).ThenBy(z => z.forename + " " + z.surname).ToList();
            string[] filePaths = Directory.GetFiles("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics");

            //filtering admin staff
            string[] depts = new string[] { "Office Administration","Information Technology","Risk and Compliance",
                "Practice Management","Finance","Performance Management","Human Resources","Marketing"};

            foreach (var item in res)
            {
                string exists = "C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + item.forename + " " + item.surname + ".png";
                if (!filePaths.Contains(exists, StringComparer.OrdinalIgnoreCase))
                {

                    string Directorsemail = hrdb.Emp_Details.Where(x => x.emp_code == item.Director_Emp_code).Select(x => x.email).FirstOrDefault();

                    var emp = new PhotoMissingVM()
                    {
                        Sno = i,
                        Name = item.forename + " " + item.surname,
                        Forename = item.forename,
                        Mail = item.email,
                        Office = item.office_code,
                        Department = item.department_it,
                        Director = Directorsemail,
                        Directormail = Directorsemail,
                        Picture_Website = item.Picture_website,
                        Request_Submitted = (booked.Contains(item.forename + " " + item.surname) ? true : false),
                        JoiningDate = item.start_date
                    };

                    pm.Add(emp);
                    i++;
                }

            }
            return pm;
        }

        public ActionResult Sendmail()
        {
            List<PhotoMissingVM> pvm = retrivestaffwithoutpics();
            foreach (var item in pvm)
            {
                try
                {
                    if (item.Name != "Ajit Lamba")
                    {
                        List<string> cc = new List<string>();
                        cc.Add(item.Directormail);
                        List<string> bcc = new List<string>();
                        bcc.Add("AjitL@Duncanlewis.com");
                        string Subject = "Submit request for the photo session";
                        string msg = "";
                        msg = "<p>Dear " + item.Forename + ",</p>";
                        msg = msg + "<p>With reference to the email sent by Sridhar on 23rd Sept at 11:30, " +
                            "I was asked by the Management board to email you personally and invite you to book a " +
                            "slot suitable for your photograph to be taken.</p><p> If you have never had a photograph taken " +
                            "after joining DL, it is mandatory to attend one of the session. Without your photograph," +
                            " your profile page on DL website and intranet will look unprofessional.</p><p> I would request" +
                            " you to book your photo session using the link below at your earliest.</p>" +
                            "<p><a href='http://10.0.0.26/PhotoSession/PhotoSession/PhotoSession_StaffAttendance'>http://10.0.0.26/PhotoSession/PhotoSession/PhotoSession_StaffAttendance</a></p>" +
                            "<p>Regards</p><p>Ajit Lamba</p>";

                        allStatic.sendemail(item.Mail, "AjitL@Duncanlewis.com", Subject, msg, cc, bcc, false, null, null);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return RedirectToAction("CheckPhotos");
        }
    }

    
}